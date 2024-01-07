using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLost : MonoBehaviour
{
    // Update is called once per frame
    void Awake()
    {
        StartCoroutine("ResetLevel");
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
