using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static SpawnContainer spawnContainer;
    public static Level currentLevel;
    private static GameObject _GameOverScreen;
    public static bool IsGameOver { get; private set; }

    private void Awake()
    {
        spawnContainer = Resources.Load<SpawnContainer>("Scriptable/ScriptableContainer/SpawnContainer");
        _GameOverScreen = GameObject.Find("HUD").transform.GetChild(4).gameObject;
        GetLevelInfo();
    }


    public static void GameOver()
    {
        print("Game over");
        _GameOverScreen.SetActive(true);
        Cursor.visible = true;
        IsGameOver = true;
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

    public static void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    private static void GetLevelInfo()
    {
        currentLevel = spawnContainer.levels[LevelCounter.currentLevel];
        CivilianManager.instance.CiviliansReamins = currentLevel.civilians;
    }


}

