using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public string startLevel;
    public string levelSelect;
    // Use this for initialization
    void Start()
    {
startLevel = "LevelOne";
    }


    public void newGame()
    {
        SceneManager.LoadScene("HighSeas");
    }

    public void LevelSelect()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
