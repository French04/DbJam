using UnityEngine;

public class CivilianManager : MonoBehaviour
{
    public static CivilianManager instance;
    private int _CivilianNumber;

    public int CiviliansReamins { get { return _CivilianNumber; } set { _CivilianNumber = value; } }

    private void Awake()
    {
        instance = this;
    }
}

