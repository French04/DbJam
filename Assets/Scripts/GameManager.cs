using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static void GameOver()
    {
        //Go to main menu
        //or restart
        print("Game over");
        LevelCounter.currentLevel = 0;
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
            print("Game Over");
        }
    }

    public static void JumpToLevel(int i)
    {
        SceneManager.LoadScene(i);
    }


}

