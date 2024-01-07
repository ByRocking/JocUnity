using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    // Update is called once per frame
    void Awake()
    {
        StartCoroutine("NextLevel");
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
