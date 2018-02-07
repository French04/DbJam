using UnityEngine;
public class CivilianManager : MonoBehaviour
{
    public static CivilianManager instance;
    private int _CivilianNumber;
    private Level _CurrentLevel;

    public int CiviliansReamins { get { return _CivilianNumber; } set { _CivilianNumber = value; } }

    private void Awake()
    {
        instance = this;
        _CurrentLevel = Resources.Load<SpawnContainer>("Scriptable/ScriptableContainer/SpawnContainer").levels[LevelCounter.currentLevel];
        _CivilianNumber = _CurrentLevel.civilians;
    }
}

