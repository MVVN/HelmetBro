using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText, hiScoreText, healthScore;
    public float scoreCount, hiScoreCount, healthScoreCount; 
    private float maxHealthScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;
    public HealthManager healthManager;
    public DeathManager deathManager;
    public AudioSource helmetCollect;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.instance = this;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        maxHealthScoreCount = healthScoreCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat ("Highscore", hiScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        hiScoreText.text = "Highscore: " + Mathf.Round(hiScoreCount);
        healthScore.text = "1up: " + Mathf.Round(healthScoreCount);

        if (healthScoreCount <= 0) {
            healthManager.AddHealth ();
            healthScoreCount = maxHealthScoreCount;
            PlayerMovement.instance.levelUp();
        }
        if (healthManager.curHealth <= 0 ) {
            DeathManager.instance.death();
            scoreIncreasing = false;
        }
    }

    public void AddScore (int pointsToAdd) 
    {
        if (scoreIncreasing) {
            scoreCount += pointsToAdd;
        }
    } 

    public void SubHealthScore(int pointsToSub)
    {
        if (scoreIncreasing) {
            helmetCollect.Play (0);
            healthScoreCount -= pointsToSub;
        }
    }

}
