using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI globText;
    public TextMeshProUGUI gemText;
    public TextMeshProUGUI powerUpText;

    int score = 0;
    int lives = 3;
    int glob = 0;
    int gem = 0;
    string powerUp = "Power Up: None";
    
    // Start is called before the first frame update

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        livesText.text = "X " + lives.ToString();
        globText.text = "X " + glob.ToString();
        gemText.text = "X " + gem.ToString();
        powerUpText.text = powerUp;


    }

    public void AddPoint(int val)
    {
        score += val;
        scoreText.text = score.ToString() + " POINTS";

    }

    public void AddGem()
    {
        gem += 1;
        gemText.text = "X " + gem.ToString();

        AddPoint(10);
    }

    public void AddGlob()
    {
        glob += 1;
        globText.text = "X " + glob.ToString();
        AddPoint(20);
    }

    public void HealthTrack(int val)
    {
        lives = val;
        livesText.text = "X " + lives.ToString();
    }
    public void PowerUpTrack(string val)
    {
        powerUp = "Power Up: " + val;
        powerUpText.text = powerUp;
    }
}
