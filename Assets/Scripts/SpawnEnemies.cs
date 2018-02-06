using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public static SpawnEnemies instance;
    public float spawnDistance = 1f;

    private List<WaveSpawn> _LevelWaves = new List<WaveSpawn>();
    private List<GameObject> _EnemyesType = new List<GameObject>();
    private Level _CurrentLevel;

    private Transform _SpawnPoint;
    private IEnumerator _SpawnEnum;
    private int _LastEnemiesStanding;

    private float _WaveTimer = 0;
    private int _WaveEnemiesCount = 0;
    private int _CurrentWave = 0;
    private float _TimeToNextWave = 0;
    private float _NextSpawnTimer = 0;

    public int LastEnemiesStanding { get { return _LastEnemiesStanding; } set { _LastEnemiesStanding = value; } }

    private void Awake()
    {
        instance = this;

        _CurrentLevel = GameObject.Find("ManagerContainers").GetComponent<SpawnContainer>().levels[LevelCounter.currentLevel];
        _SpawnPoint = GameObject.Find("SpawnPoint").transform;
        //_SpawnEnum = Spawn();

        foreach (WaveSpawn waves in _CurrentLevel.waveNumber)
        {
            _LevelWaves.Add(waves);
        }

        GetWaveInfo();
    }



    private void Update()
    {
        if (_WaveTimer > 0)
        {
            _WaveTimer -= Time.deltaTime;
            
        }
        else
        {
            StopEnemiesSpawn();
        }
    }

    private void GetWaveInfo()
    {
        if (_EnemyesType.Count > 0)
            _EnemyesType.Clear();

        foreach (GameObject go in _CurrentLevel.waveNumber[_CurrentWave].typeOfEnemies)
        {
            _EnemyesType.Add(go);
        }

        _WaveTimer = _LevelWaves[_CurrentWave].waveTimer;
        _WaveEnemiesCount = ReturnEnemiesCount();
        _TimeToNextWave = _LevelWaves[_CurrentWave].timeToNextWave;
        _NextSpawnTimer = _LevelWaves[_CurrentWave].nextSpawnCountDown;
        StartCoroutine(_SpawnEnum = Spawn());
        
    }

    private IEnumerator Spawn()
    {
        print("Spawn enemies");
        for(int i = 0; i < ReturnRandomEnemiesNumber(); i++)
        {
            var clone = Instantiate(RandomEnemy());
            clone.transform.position = new Vector2(_SpawnPoint.position.x + i * spawnDistance , _SpawnPoint.position.y);
            _WaveEnemiesCount--;

            if (_WaveEnemiesCount <= 0)
            {
                StartCoroutine(StopEnemiesSpawn());
            }

            yield return null;
        }
        
        yield return new WaitForSeconds(_NextSpawnTimer);
        StartCoroutine(_SpawnEnum = Spawn());
    }

    private IEnumerator StopEnemiesSpawn()
    {
        StopCoroutine(_SpawnEnum);


        yield return StartCoroutine(CheckEnemiesLeft());
        yield return StartCoroutine(WaitForTheNextWave());

        if (_CurrentWave < _LevelWaves.Count -1)
        {
            print("Call next wave");
            _CurrentWave++;
            GetWaveInfo();
        }
        else
        {
            print("Waves over, good job (trigger go to the next level)");
            //SceneManager.LoadAsync(level++);
        }
        yield return null;
    }

    private IEnumerator WaitForTheNextWave()
    {
        print("Shopping time!");
        yield return new WaitForSeconds(_TimeToNextWave);
        print("Shopping time over");
    }

    private IEnumerator CheckEnemiesLeft()
    {
        GetLastEnemiesLeft();

        while(_LastEnemiesStanding > 0)
        {
            yield return null;
        }
        print("Wave Cleared");
    }

    private void GetLastEnemiesLeft()
    {
        _LastEnemiesStanding = GameObject.FindGameObjectsWithTag("Enemy").Length;
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
        print(enemy1 + enemy2 + enemy3 + enemy4 + enemy5 + enemy6 + enemy7 + enemy8 + enemy9);
        return enemy1 + enemy2 + enemy3 + enemy4 + enemy5 + enemy6 + enemy7 + enemy8 + enemy9;
    }



}
