using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using System;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        public EnemyController enemy;
        public PlayerController player;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var willHurtEnemy = player.Bounds.center.y >= enemy.Bounds.max.y;

            if (willHurtEnemy)
            {
                var enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Decrement();
                    if (!enemyHealth.IsAlive)
                    {
                        Schedule<EnemyDeath>().enemy = enemy;
                        ScoreManager.instance.AddGlob();
                        player.Bounce(2);
                    }
                    else
                    {
                        player.Bounce(7);
                    }
                }
                else
                {
                    Schedule<EnemyDeath>().enemy = enemy;
                    ScoreManager.instance.AddGlob();
                    player.Bounce(2);
                }
            }
            else
            {
                var playerHealth = player.health;
                Debug.Log(playerHealth);
                if (playerHealth > 1)
                {
                    player.health -= 1;
                    ScoreManager.instance.HealthTrack(player.health);
                }
                else
                {
                    Debug.Log("PLAYER DEATH");
                    Schedule<PlayerDeath>();
                }
            }
        }
    }
}