using UnityEngine;
[CreateAssetMenu(fileName = "Level", menuName = "Tools/Level", order = 2)]
public class Level : ScriptableObject
{
    public WaveSpawn[] waveNumber;
    public int civilians;
    public GameObject boss;
}
