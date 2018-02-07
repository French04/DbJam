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
    private EnemiesCounter _EnemiesCounter;
    private GameObject _Boss;

    private Transform _SpawnPoint;
    private IEnumerator _SpawnEnum;
    private int _LastEnemiesStanding;

    private bool _TimeTrigger = true;
    private float _WaveTimer = 0;
    private int _WaveEnemiesCount = 0;
    private int _CurrentWave = 0;
    private float _TimeToNextWave = 0;
    private float _NextSpawnTimer = 0;

    public int LastEnemiesStanding { get { return _LastEnemiesStanding; } set { _LastEnemiesStanding = value; } }

    private void Awake()
    {
        instance = this;
        
        _CurrentLevel = Resources.Load<SpawnContainer>("Scriptable/ScriptableContainer/SpawnContainer").levels[LevelCounter.currentLevel];
        _Boss = _CurrentLevel.boss;
        _SpawnPoint = GameObject.Find("SpawnPoint").transform;
        _SpawnEnum = Spawn();

        foreach (WaveSpawn waves in _CurrentLevel.waveNumber )
        {
            _LevelWaves.Add(waves);
        }

        GetWaveInfo();
    }


    private void Update()
    {
        if (_WaveTimer > 0 && _TimeTrigger)
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
        _TimeTrigger = true;
        StartCoroutine(_SpawnEnum = Spawn());
        
    }

    private IEnumerator Spawn()
    {
        print("Spawn enemies");
        
        for(int i = 0; i < ReturnRandomEnemiesNumber(); i++)
        {
            var clone = Instantiate(RandomEnemy());
            clone.transform.position = new Vector2(_SpawnPoint.position.x + i * spawnDistance , _SpawnPoint.position.y);
            if (clone.name.Contains("Flying"))
            {
                var _NewPos = clone.transform.position;
                _NewPos.y += 10;
                clone.transform.position = _NewPos;
            }
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
            if (_Boss != null)
            {
                yield return StartCoroutine(BossFight());
                yield return StartCoroutine(WaitForTheNextWave());
            }
            print("Waves over, good job (trigger go to the next level)");
            //SceneManager.LoadAsync(level++);
            GameManager.NextLevel();
        }
        yield return null;
    }

    private IEnumerator WaitForTheNextWave()
    {
        print("Shopping time!");
        _TimeTrigger = false;
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

    private IEnumerator BossFight()
    {
        var clone = Instantiate(_Boss);
        clone.transform.position = _SpawnPoint.position;
        print("Boss spawned");

        while(clone.gameObject != null)
        {
            yield return null;
        }

        print("Boss null");
    }

    private void GetLastEnemiesLeft()
    {
        _LastEnemiesStanding = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private GameObject RandomEnemy()
    {
        int _RandomEnemy = 0;
        string _EnemyName = "";

        var loop = true;
        while(loop)
        {
            loop = false;
            _RandomEnemy  = Random.Range(0, _EnemyesType.Count);
            _EnemyName = _EnemyesType[_RandomEnemy].name;
            print(_EnemyName);

            if (_EnemyName == "LightEnemy" && _EnemiesCounter.lightEnemies > 0)
            {
                _EnemiesCounter.lightEnemies--;
            }
            else if (_EnemyName == "LightEnemyV2" && _EnemiesCounter.lightEnemiesV2 > 0)
            {
                _EnemiesCounter.lightEnemiesV2--;
            }
            else if (_EnemyName == "LightEnemyV3" && _EnemiesCounter.lightEnemiesV3 > 0)
            { 
                _EnemiesCounter.lightEnemiesV3--;
            }
            else if (_EnemyName == "FlyingEnemy" && _EnemiesCounter.flyingEnemies > 0)
            {
                _EnemiesCounter.flyingEnemies--;
            }
            else if (_EnemyName == "FlyingEnemyV2" && _EnemiesCounter.flyingEnemiesV2 > 0)
            {
                _EnemiesCounter.flyingEnemiesV2--;
            }
            else if (_EnemyName == "FlyingEnemyV3" && _EnemiesCounter.flyingEnemiesV3 > 0)
            {
                _EnemiesCounter.flyingEnemiesV3--;
            }
            else if (_EnemyName == "HeavyEnemy" && _EnemiesCounter.heavyEnemies > 0)
            {
                _EnemiesCounter.heavyEnemies--;
            }
            else if (_EnemyName == "HeavyEnemyV2" && _EnemiesCounter.heavyEnemiesV2 > 0)
            {
                _EnemiesCounter.heavyEnemiesV2--;
            }
            else if (_EnemyName == "HeavyEnemyV3" && _EnemiesCounter.heavyEnemiesV3 > 0)
            {
                _EnemiesCounter.heavyEnemiesV3--;
            }
            else
            {
                loop = true;
            }

        }

        return _EnemyesType[_RandomEnemy];

    }

    private int ReturnRandomEnemiesNumber()
    {
        return Random.Range(_LevelWaves[_CurrentWave].randomMinEnemies, _LevelWaves[_CurrentWave].randomMaxEnemies);
    }

    private int ReturnEnemiesCount()
    {
        _EnemiesCounter = null;
        _EnemiesCounter = new EnemiesCounter();

        _EnemiesCounter.lightEnemies = _LevelWaves[_CurrentWave].lightEnemies;
        _EnemiesCounter.lightEnemiesV2 = _LevelWaves[_CurrentWave].lightEnemiesV2;
        _EnemiesCounter.lightEnemiesV3 = _LevelWaves[_CurrentWave].lightEnemiesV3;
        _EnemiesCounter.flyingEnemies = _LevelWaves[_CurrentWave].flyingEnemies;
        _EnemiesCounter.flyingEnemiesV2 = _LevelWaves[_CurrentWave].flyingEnemiesV2;
        _EnemiesCounter.flyingEnemiesV3 = _LevelWaves[_CurrentWave].flyingEnemiesV3;
        _EnemiesCounter.heavyEnemies = _LevelWaves[_CurrentWave].heavyEnemies;
        _EnemiesCounter.heavyEnemiesV2 = _LevelWaves[_CurrentWave].heavyEnemiesV2;
        _EnemiesCounter.heavyEnemiesV3 = _LevelWaves[_CurrentWave].heavyEnemiesV3;

        print(_EnemiesCounter.lightEnemies + "" + _EnemiesCounter.lightEnemiesV2 + "" + _EnemiesCounter.lightEnemiesV3 + "" + _EnemiesCounter.flyingEnemies 
                + "" + _EnemiesCounter.flyingEnemiesV2 + "" + _EnemiesCounter.flyingEnemiesV3 + "" + _EnemiesCounter.heavyEnemies + "" +_EnemiesCounter.heavyEnemiesV2 
                + "" + _EnemiesCounter.heavyEnemiesV3);
        print(_EnemiesCounter.lightEnemies + _EnemiesCounter.lightEnemiesV2 + _EnemiesCounter.lightEnemiesV3 + _EnemiesCounter.flyingEnemies + _EnemiesCounter.flyingEnemiesV2
                + _EnemiesCounter.flyingEnemiesV3 + _EnemiesCounter.heavyEnemies + _EnemiesCounter.heavyEnemiesV2 + _EnemiesCounter.heavyEnemiesV3);

        return _EnemiesCounter.lightEnemies + _EnemiesCounter.lightEnemiesV2 + _EnemiesCounter.lightEnemiesV3 + _EnemiesCounter.flyingEnemies + _EnemiesCounter.flyingEnemiesV2
                + _EnemiesCounter.flyingEnemiesV3 + _EnemiesCounter.heavyEnemies + _EnemiesCounter.heavyEnemiesV2 + _EnemiesCounter.heavyEnemiesV3;
    }



}
