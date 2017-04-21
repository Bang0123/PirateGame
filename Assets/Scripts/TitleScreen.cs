using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void newGame()
    {
        SceneManager.LoadScene("HighSeas");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
