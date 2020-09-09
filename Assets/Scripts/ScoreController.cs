using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    private int scorePoint;
    public int enemyDeathCount;
    private float timeScore;
    private float comboTime;
    public int comboCount;
    private int comboScore;
    private int highScore;
    private GameInterFace gameInterFace;
    public int ScorePoint
    {
        get { return scorePoint; }
        set { scorePoint = value; }
    }
    public int HighScore
    {
        get { return highScore; }
        set { highScore = value; }
    }
    void Awake()
    {
        Instance = GetComponent<ScoreController>();
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    private void Update()
    {
        GetComponent<GameInterFace>().scoreText.text="Score: " + scorePoint;
        GetComponent<GameInterFace>().scoreTextPanel.text = "Score: " + scorePoint; 
        
        if (scorePoint>highScore)
        {
            highScore = scorePoint;
            PlayerPrefs.SetInt("HighScore", HighScore);
        }
        Score();
        GetComponent<GameInterFace>().HighScoreTextPanel.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }
    private void Score()
    {
        comboTime += 1 * Time.deltaTime;
        if(comboTime<5.00f)
        {
            if(comboCount==3)
            {
                comboScore = 25;
            }
            if (comboCount == 5)
            {
                comboScore = 75;
            }
        }
        else if(comboTime> 5.00f)
        {
            scorePoint += comboScore;
            comboScore = 0;
            comboTime = 0;
            comboCount = 0;
        }
        timeScore += 1 * Time.deltaTime;
        if (timeScore > 1.00f)
        {
            scorePoint += (int)timeScore;
            timeScore = 0;
        }
        if (enemyDeathCount == 10)
        {
            scorePoint += 100;
            enemyDeathCount = 0;
        }
    }     
}
