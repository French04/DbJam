using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static void GameOver()
    {
        print("Game over");

        Pause.instance.gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        
    }

    public static void NextLevel()
    {
        if (LevelCounter.currentLevel < 13)
        {
            LevelCounter.currentLevel++;
            SceneManager.LoadScene(LevelCounter.currentLevel);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            LevelCounter.currentLevel = 0;
            print("Game Over");
        }
    }

    public static void JumpToLevel(int i)
    {
        SceneManager.LoadScene(i);
    }


}

