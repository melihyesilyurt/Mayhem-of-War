using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    private int goldCoin;
    private int scorePoint;
    public int enemyDeathCount;
    private float timeScore;
    private float comboTime;
    public int comboCount;
    private int comboScore;
    private int highScore;
    public int GoldCoin
    {
        get { return goldCoin; }
        set { goldCoin = value; }
    }
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
    }
    private void Update()
    {
        if(scorePoint>highScore)
        {
            highScore = scorePoint;
        }
        Score();     
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
