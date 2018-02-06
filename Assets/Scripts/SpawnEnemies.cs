using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float spawnDistance = 1f;

    private List<WaveSpawn> _LevelWaves = new List<WaveSpawn>();
    private List<GameObject> _EnemyesType = new List<GameObject>();
    private Level _CurrentLevel;

    private Transform _SpawnPoint;
    private IEnumerator _SpawnEnum;

    private int _WaveEnemiesCount;
    private int _CurrentWave = 0;

    private void Awake()
    {
        _CurrentLevel = GameObject.Find("ManagerContainers").GetComponent<SpawnContainer>().levels[LevelCounter.currentLevel];
        _SpawnPoint = GameObject.Find("SpawnPoint").transform;
        _SpawnEnum = Spawn();

        foreach (WaveSpawn waves in _CurrentLevel.waveNumber)
        {
            _LevelWaves.Add(waves);
        }
        foreach (GameObject go in _CurrentLevel.waveNumber[_CurrentWave].typeOfEnemies)
        {
            _EnemyesType.Add(go);
        }

        _WaveEnemiesCount = ReturnEnemiesCount();
        StartCoroutine(_SpawnEnum);
    }

    private void Update()
    {

    }

    private IEnumerator Spawn()
    {
        for(int i = 0; i < ReturnRandomEnemiesNumber(); i++)
        {
            var clone = Instantiate(RandomEnemy());
            clone.transform.position = new Vector2(_SpawnPoint.position.x + i * spawnDistance , _SpawnPoint.position.y);
            yield return null;
        }

        _CurrentWave++;
        yield return new WaitForSeconds(_LevelWaves[_CurrentWave].nextSpawnCountDown);
        StartCoroutine(_SpawnEnum);
    }



    private GameObject RandomEnemy()
    {
        var random = Random.Range(0, _EnemyesType.Count);
        return _EnemyesType[random];

    }

    private int ReturnRandomEnemiesNumber()
    {
        return Random.Range(_LevelWaves[_CurrentWave].randomMinEnemies, _LevelWaves[_CurrentWave].randomMaxEnemies);
    }


    private int ReturnEnemiesCount()
    {
        var enemy1 = _LevelWaves[_CurrentWave].lightEnemies;
        var enemy2 = _LevelWaves[_CurrentWave].lightEnemiesV2;
        var enemy3 = _LevelWaves[_CurrentWave].lightEnemiesV3;
        var enemy4 = _LevelWaves[_CurrentWave].flyingEnemies;
        var enemy5 = _LevelWaves[_CurrentWave].flyingEnemiesV2;
        var enemy6 = _LevelWaves[_CurrentWave].flyingEnemiesV3;
        var enemy7 = _LevelWaves[_CurrentWave].heavyEnemies;
        var enemy8 = _LevelWaves[_CurrentWave].heavyEnemiesV2;
        var enemy9 = _LevelWaves[_CurrentWave].heavyEnemiesV3;
        return enemy1 + enemy2 + enemy3 + enemy4 + enemy5 + enemy6 + enemy7 + enemy8 + enemy9;
    }
}
