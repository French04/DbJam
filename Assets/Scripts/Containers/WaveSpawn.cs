using UnityEngine;

[CreateAssetMenu(fileName = "Waves", menuName = "Tools/Waves", order = 1)]
public class WaveSpawn : ScriptableObject
{

    public int lightEnemies;
    public int lightEnemiesV2;
    public int lightEnemiesV3;
    public int heavyEnemies;
    public int heavyEnemiesV2;
    public int heavyEnemiesV3;
    public int flyingEnemies;
    public int flyingEnemiesV2;
    public int flyingEnemiesV3;


    public float waveTimer;
    public float nextSpawnCountDown;
    public float timeToNextWave;

    public int randomMinEnemies;
    public int randomMaxEnemies;

    public GameObject[] typeOfEnemies;

}
