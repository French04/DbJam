using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static void GameOver()
    {
        //Go to main menu
        //or restart
        LevelCounter.currentLevel = 0;
    }

    public static void NextLevel()
    {
        LevelCounter.currentLevel++;
        SceneManager.LoadScene(LevelCounter.currentLevel);
    }
}

