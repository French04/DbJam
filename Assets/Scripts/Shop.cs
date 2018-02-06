using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Image[] Weapon;

    [HideInInspector]
    public int money = 0;

    [HideInInspector]
    public int WeaponSelected = 0;

    public void SelectWeapon(int choise)
    {
        WeaponSelected = choise;
    }
}
