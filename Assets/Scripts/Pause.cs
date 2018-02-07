using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static Pause instance;

    private void Awake()
    {
        instance = this;
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void MainMenuLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void Exit()
    {
        Application.Quit();
    }

}
