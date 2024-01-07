using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int scoreValue = 1000;
    float nextSec = 1f;

    public TMP_Text scoreText;

    public static Score instance;

    void Start()
    {
        scoreValue = 1000;
        if (!instance)
        {
            instance = this;
        }
        IncreaseScore(0);
    }

    void Update()
    {
        if (scoreValue > 0)
        {
            nextSec -= Time.deltaTime;
            if (nextSec < 0)
            {
                scoreValue -= 9;
                nextSec = 1f;
            }
        }
        else
        {
            scoreValue = 0;
        }
        DisplayScore(scoreValue);
    }

    public void IncreaseScore(int score)
    {
        scoreValue += score * score;
    }

    void DisplayScore(int scoreDisplay)
    {
        if (scoreDisplay < 0)
        {
            scoreDisplay = 0;
        }
        scoreText.text = "Score: " + scoreDisplay.ToString();
    }

    public int PassScore()
    {
        return scoreValue;
    }
}
