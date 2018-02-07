using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalorBar : MonoBehaviour
{
    GameObject[] feedbackBlock = new GameObject[5];

    Shop shop;


    float calor = 0;
    public float maxCalor = 125;
    public int Step1 = 25;
    public int Step2 = 50;
    public int Step3 = 75;
    public int Step4 = 100;
    public int Step5 = 125;

    public int calorIncrease = 20;
    public int calorDecrease = 20;

    // Use this for initialization
    void Start ()
    {
        shop = FindObjectOfType<Shop>();

        for (int i = 0; i < feedbackBlock.Length; i++)
        {
            feedbackBlock[i] = transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(shop.WeaponSelected == 7 || shop.WeaponSelected == 9)
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
        }

        //block1
        if(calor < Step1 && feedbackBlock[0].activeSelf)
        {
            feedbackBlock[0].SetActive(false);
        }
        else if(calor >= Step1 && !feedbackBlock[0].activeSelf)
        {
            feedbackBlock[0].SetActive(true);
        }

        //block2
        if (calor < Step2 && feedbackBlock[1].activeSelf)
        {
            feedbackBlock[1].SetActive(false);
        }
        else if (calor >= Step2 && !feedbackBlock[1].activeSelf)
        {
            feedbackBlock[1].SetActive(true);
        }

        //block3
        if (calor < Step3 && feedbackBlock[2].activeSelf)
        {
            feedbackBlock[2].SetActive(false);
        }
        else if (calor >= Step3 && !feedbackBlock[2].activeSelf)
        {
            feedbackBlock[2].SetActive(true);
        }

        //block4
        if (calor < Step4 && feedbackBlock[3].activeSelf)
        {
            feedbackBlock[3].SetActive(false);
        }
        else if (calor >= Step4 && !feedbackBlock[3].activeSelf)
        {
            feedbackBlock[3].SetActive(true);
        }

        //block5
        if (calor < Step5 && feedbackBlock[4].activeSelf)
        {
            feedbackBlock[4].SetActive(false);
        }
        else if (calor >= Step5 && !feedbackBlock[4].activeSelf)
        {
            feedbackBlock[4].SetActive(true);
        }
    }
}
