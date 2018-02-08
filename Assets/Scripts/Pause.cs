using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static Pause instance;
    public GameObject gameOverScreen;

    OrganCollector organCollector;

    private void Awake()
    {
        instance = this;
        organCollector = FindObjectOfType<OrganCollector>();
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
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        LevelCounter.currentLevel = 0;
    }

    public void RetryMission()
    {
        organCollector.brain = 0;
        organCollector.heart = 0;
        organCollector.intestine = 0;
        organCollector.kidney = 0;
        organCollector.liver = 0;
        organCollector.lung = 0;

        Time.timeScale = 1;
        SceneManager.LoadScene(LevelCounter.currentLevel);
    }


    public void Exit()
    {
        Application.Quit();
    }

}
