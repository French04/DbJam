using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static SpawnContainer spawnContainer;
    public static Level currentLevel;

    private void Awake()
    {
        spawnContainer = Resources.Load<SpawnContainer>("Scriptable/ScriptableContainer/SpawnContainer");
        GetLevelInfo();
    }


    public static void GameOver()
    {
        print("Game over");
        GameObject.Find("HUD").GetComponent<Pause>().gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        
    }

    public static IEnumerator NextLevel()
    {
        if (LevelCounter.currentLevel < 14)
        {
            LevelCounter.currentLevel++;
            GetLevelInfo();
            print("Waiting next level");
            yield return new WaitForSeconds(2.0f);
            print("Start next Level");
            
        }
        else
        {
            //Game completed screen
            SceneManager.LoadScene("MainMenu");
            LevelCounter.currentLevel = 0;
            print("Game Completed");
        }
    }

    public static void JumpToLevel(int i)
    {
        SceneManager.LoadScene(i);
    }

    private static void GetLevelInfo()
    {
        currentLevel = spawnContainer.levels[LevelCounter.currentLevel];
        CivilianManager.instance.CiviliansReamins = currentLevel.civilians;
    }


}

