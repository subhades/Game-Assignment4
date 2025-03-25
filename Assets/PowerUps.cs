using Platformer.Gameplay;
using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PowerUps : MonoBehaviour
{
    internal bool collected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //only exectue OnPlayerEnter if the player collides with this token.
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null) OnPlayerEnter(player);
    }

    void OnPlayerEnter(PlayerController player)
    {
        if (this.CompareTag("Speed"))
        {
            Debug.Log("NEED FOR SPEED");
            ScoreManager.instance.PowerUpTrack("Speed");

            player.SpecialAbility("Speed");
            Destroy(GameObject.FindWithTag("Speed"));
        }
        else if (this.CompareTag("Jump"))
        {
            Debug.Log("JUMP JUMP JUMP");
            ScoreManager.instance.PowerUpTrack("Jump");
            player.SpecialAbility("JUMP");
            Destroy(this);
        }
    }
}
