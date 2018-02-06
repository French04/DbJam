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

    Player player;

    private void Start()
    {
        Weapon[0].purchased = true;

        player = FindObjectOfType<Player>();
    }

    public void SelectWeapon(int choise)
    {
        //if the weapon is buyable
        if (Weapon[choise].imEnabled)
        {
            //if i have already buy this weapon
            if(Weapon[choise].purchased == true)
            {
                Debug.Log("arma già acquistata");
                WeaponSelected = choise;

                InstantiateWeapon();
            }
            else
            {
                Debug.Log("arma nuova");
                organ1 -= Weapon[choise].organ1value;
                organ2 -= Weapon[choise].organ2value;
                organ3 -= Weapon[choise].organ3value;
                organ4 -= Weapon[choise].organ4value;
                organ5 -= Weapon[choise].organ5value;
                organ6 -= Weapon[choise].organ6value;

                WeaponSelected = choise;
                Weapon[choise].purchased = true;

                InstantiateWeapon();
            }
        }
    }

    void InstantiateWeapon()
    {
        Destroy(player.currentWeapon);

        switch (WeaponSelected)
        {

            case 0:
                GameObject weaponPrefab0 = Resources.Load("Weapons/Winchester") as GameObject;
                player.currentWeapon = Instantiate(weaponPrefab0, transform.position, Quaternion.identity);
                break;
            case 1:
                GameObject weaponPrefab1 = Resources.Load("Weapons/Sniper") as GameObject;
                player.currentWeapon = Instantiate(weaponPrefab1, transform.position, Quaternion.identity);
                break;
            case 2:
                GameObject weaponPrefab2 = Resources.Load("Weapons/SniperSuper") as GameObject;
                player.currentWeapon = Instantiate(weaponPrefab2, transform.position, Quaternion.identity);
                break;
            case 3:
                GameObject weaponPrefab3 = Resources.Load("Weapons/Bazooka") as GameObject;
                player.currentWeapon = Instantiate(weaponPrefab3, transform.position, Quaternion.identity);
                break;
            case 4:
                GameObject weaponPrefab4 = Resources.Load("Weapons/Shotgun") as GameObject;
                player.currentWeapon = Instantiate(weaponPrefab4, transform.position, Quaternion.identity);
                break;
            case 5:
                GameObject weaponPrefab5 = Resources.Load("Weapons/ShotgunSuper") as GameObject;
                player.currentWeapon = Instantiate(weaponPrefab5, transform.position, Quaternion.identity);
                break;
            case 6:
                GameObject weaponPrefab6 = Resources.Load("Weapons/GranadeLauncher") as GameObject;
                player.currentWeapon = Instantiate(weaponPrefab6, transform.position, Quaternion.identity);
                break;
            case 7:
                GameObject weaponPrefab7 = Resources.Load("Weapons/MachineGunLight") as GameObject;
                player.currentWeapon = Instantiate(weaponPrefab7, transform.position, Quaternion.identity);
                break;
            case 8:
                GameObject weaponPrefab8 = Resources.Load("Weapons/MachineGunTriple") as GameObject;
                player.currentWeapon = Instantiate(weaponPrefab8, transform.position, Quaternion.identity);
                break;
            case 9:
                GameObject weaponPrefab9 = Resources.Load("Weapons/Gatling") as GameObject;
                player.currentWeapon = Instantiate(weaponPrefab9, transform.position, Quaternion.identity);
                break;

        }

    }
}
