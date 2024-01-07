using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 5f;

    public GameObject completeLevelUI;
    public GameObject lostLevelUI;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            lostLevelUI.SetActive(true);
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
