using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Shop : MonoBehaviour
{
    EnablerWeapon[] weapon = new EnablerWeapon[10];

    GameObject wincester, shotGun, sniper, smg, sniperPlus, bazooka, shotgunPlus, granadeLauncher, machineGunSemiAuto, gatling;

    //[HideInInspector]
    //public int organ1 = 0, organ2 = 0, organ3 = 0, organ4 = 0, organ5 = 0, organ6 = 0;

    [HideInInspector]
    public int WeaponSelected = 0;

    Player player;

    OrganCollector organCollector;

    public AudioClip buySound;
    private AudioSource audioSource;

    private void Start()
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            weapon[i] = transform.GetChild(i).GetComponent<EnablerWeapon>();
        }

        weapon[0].purchased = true;

        player = FindObjectOfType<Player>();

        organCollector = FindObjectOfType<OrganCollector>();

        #region Weapon
        wincester = GameObject.Find("Wpn_Winchester").gameObject;

        shotGun = GameObject.Find("Wpn_Shotgun").gameObject;
        shotGun.SetActive(false);

        sniper = GameObject.Find("Wpn_Sniper").gameObject;
        sniper.SetActive(false);

        smg = GameObject.Find("Wpn_SMG").gameObject;
        smg.SetActive(false);

        sniperPlus = GameObject.Find("Wpn_SniperPlus").gameObject;
        sniperPlus.SetActive(false);

        bazooka = GameObject.Find("Wpn_Bazooka").gameObject;
        bazooka.SetActive(false);

        shotgunPlus = GameObject.Find("Wpn_ShotgunPlus").gameObject;
        shotgunPlus.SetActive(false);

        granadeLauncher = GameObject.Find("Wpn_GranadeLauncher").gameObject;
        granadeLauncher.SetActive(false);

        machineGunSemiAuto = GameObject.Find("Wpn_MachineGunSemiAuto").gameObject;
        machineGunSemiAuto.SetActive(false);

        gatling = GameObject.Find("Wpn_Gatling").gameObject;
        gatling.SetActive(false);
        #endregion

        player.currentWeapon = wincester;

        ChangeColor();

        gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    public void SelectWeapon(int choise)
    {
        //if the weapon is buyable
        if (weapon[choise].imEnabled)
        {
            //if i have already buy this weapon
            if(weapon[choise].purchased == true)
            {
                //arma già acquistata
                WeaponSelected = choise;

                InstantiateWeapon();
            }
            else
            {
                audioSource.PlayOneShot(buySound);
                //arma nuova
                organCollector.heart -= weapon[choise].heart;
                organCollector.brain -= weapon[choise].brain;
                organCollector.lung -= weapon[choise].lung;
                organCollector.kidney -= weapon[choise].kidney;
                organCollector.intestine -= weapon[choise].intestine;
                organCollector.liver -= weapon[choise].liver;

                WeaponSelected = choise;
                weapon[choise].purchased = true;

                InstantiateWeapon();
            }
        }
    }

    void InstantiateWeapon()
    {
        player.currentWeapon.SetActive(false);

        switch (WeaponSelected)
        {

            case 0:               
                player.currentWeapon = wincester;
                player.currentWeapon.SetActive(true);

                break;
            case 1:
                player.currentWeapon = sniper;
                player.currentWeapon.SetActive(true);
                break;
            case 2:
                player.currentWeapon = sniperPlus;
                player.currentWeapon.SetActive(true);
                break;
            case 3:
                player.currentWeapon = bazooka;
                player.currentWeapon.SetActive(true);
                break;
            case 4:
                player.currentWeapon = shotGun;
                player.currentWeapon.SetActive(true);
                break;
            case 5:
                player.currentWeapon = shotgunPlus;
                player.currentWeapon.SetActive(true);
                break;
            case 6:
                player.currentWeapon = granadeLauncher;
                player.currentWeapon.SetActive(true);
                break;
            case 7:
                player.currentWeapon = smg;
                player.currentWeapon.SetActive(true);
                break;
            case 8:
                player.currentWeapon = machineGunSemiAuto;
                player.currentWeapon.SetActive(true);
                break;
            case 9:
                player.currentWeapon = gatling;
                player.currentWeapon.SetActive(true);
                break;

        }

        ChangeColor();
    }

    void ChangeColor()
    {
        weapon[WeaponSelected].iAmCurrentWeapon = true;

        for (int i = 0; i < weapon.Length; i++)
        {
            if (weapon[i] == weapon[WeaponSelected])
                continue;

            weapon[i].iAmCurrentWeapon = false;
        }
    }
}
