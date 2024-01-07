using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text highscore;
    int scoreValue = 18;

    void Start()
    {
        Cursor.visible = true;
        scoreValue = Score.instance.PassScore();
        score.text = "Score: " + scoreValue.ToString();
        if (scoreValue > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreValue);
            highscore.text = "HighScore: " + scoreValue.ToString();
        }
        else
        {
            highscore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highscore.text = "HighScore: " + "0";
    }
}
