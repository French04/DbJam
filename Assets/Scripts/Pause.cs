using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static Pause instance;
    public GameObject gameOverScreen;

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
        LevelCounter.currentLevel = 0;
    }

    public void RetryMission()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(LevelCounter.currentLevel);
    }


    public void Exit()
    {
        Application.Quit();
    }

}
