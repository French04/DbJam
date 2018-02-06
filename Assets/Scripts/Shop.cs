using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public EnablerWeapon[] Weapon;

    //[HideInInspector]
    public int organ1 = 0, organ2 = 0, organ3 = 0, organ4 = 0, organ5 = 0, organ6 = 0;

    [HideInInspector]
    public int WeaponSelected = 0;

    private void Start()
    {
        Weapon[0].purchased = true;
    }

    public void SelectWeapon(int choise)
    {
        //if the weapon is buyable
        if (Weapon[choise].imEnabled)
        {
            //if i have already buy this weapon
            if(Weapon[choise].purchased == true)
            {
                WeaponSelected = choise;
            }
            else
            {
                organ1 -= Weapon[choise].organ1value;
                organ2 -= Weapon[choise].organ2value;
                organ3 -= Weapon[choise].organ3value;
                organ4 -= Weapon[choise].organ4value;
                organ5 -= Weapon[choise].organ5value;
                organ6 -= Weapon[choise].organ6value;

                WeaponSelected = choise;
                Weapon[choise].purchased = true;
            }
        }
    }
}
