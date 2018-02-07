using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnContainer", menuName = "Tools/SpawnContainer", order = 3)]
public class SpawnContainer : ScriptableObject
{
    public List<Level> levels = new List<Level>();

}
