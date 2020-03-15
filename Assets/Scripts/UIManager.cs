using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadDeathScreen()
    {
        StartCoroutine(WaitAndLoad());
    }
    
    public void LoadFailScene()
    {
        SceneManager.LoadScene(4);
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
