using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalorBar : MonoBehaviour
{
    GameObject[] feedbackBlock = new GameObject[5];

    Shop shop;

    Player player;

    //float calor = 0;
    //public float maxCalor = 125;
    int Step1 = 20;
    int Step2 = 40;
    int Step3 = 60;
    int Step4 = 80;
    int Step5 = 100;

    //public int calorIncrease = 20;
    //public int calorDecrease = 20;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        shop = FindObjectOfType<Shop>();

        for (int i = 0; i < feedbackBlock.Length; i++)
        {
            feedbackBlock[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if(shop.WeaponSelected == 7 || shop.WeaponSelected == 9)
        {
            //increase calor valor if the player shoot with the gatling o machineGun
            if (Input.GetMouseButton(0))
            {
                if (calor <= maxCalor)
                    calor += calorIncrease * Time.deltaTime;
            }
            else //decrease calor if the player dont shoot
            {
                if(calor > 0)
                    calor -= calorDecrease * Time.deltaTime;
            }
        }

        //decrease calor valor if the weapon don't have calorBar
        if (shop.WeaponSelected != 7 && shop.WeaponSelected != 9 && calor != 0)
        {
            calor -= calorDecrease * Time.deltaTime; ;
        }*/


        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            //block1
            if (player.currentWeapon.GetComponent<Weapon>().heatLevel < Step1 && feedbackBlock[0].activeSelf)
            {
                feedbackBlock[0].SetActive(false);
            }
            else if (player.currentWeapon.GetComponent<Weapon>().heatLevel >= Step1 && !feedbackBlock[0].activeSelf)
            {
                feedbackBlock[0].SetActive(true);
            }

            //block2
            if (player.currentWeapon.GetComponent<Weapon>().heatLevel < Step2 && feedbackBlock[1].activeSelf)
            {
                feedbackBlock[1].SetActive(false);
            }
            else if (player.currentWeapon.GetComponent<Weapon>().heatLevel >= Step2 && !feedbackBlock[1].activeSelf)
            {
                feedbackBlock[1].SetActive(true);
            }

            //block3
            if (player.currentWeapon.GetComponent<Weapon>().heatLevel < Step3 && feedbackBlock[2].activeSelf)
            {
                feedbackBlock[2].SetActive(false);
            }
            else if (player.currentWeapon.GetComponent<Weapon>().heatLevel >= Step3 && !feedbackBlock[2].activeSelf)
            {
                feedbackBlock[2].SetActive(true);
            }

            //block4
            if (player.currentWeapon.GetComponent<Weapon>().heatLevel < Step4 && feedbackBlock[3].activeSelf)
            {
                feedbackBlock[3].SetActive(false);
            }
            else if (player.currentWeapon.GetComponent<Weapon>().heatLevel >= Step4 && !feedbackBlock[3].activeSelf)
            {
                feedbackBlock[3].SetActive(true);
            }

            //block5
            if (player.currentWeapon.GetComponent<Weapon>().heatLevel < Step5 && feedbackBlock[4].activeSelf)
            {
                feedbackBlock[4].SetActive(false);
            }
            else if (player.currentWeapon.GetComponent<Weapon>().heatLevel >= Step5 && !feedbackBlock[4].activeSelf)
            {
                feedbackBlock[4].SetActive(true);
            }
        }
    }
}
