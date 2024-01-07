using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                //Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
