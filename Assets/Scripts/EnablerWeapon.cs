using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnablerWeapon : MonoBehaviour
{
    [HideInInspector]
    public bool imEnabled = true;

    [HideInInspector]
    public bool purchased = false;

    Image myImage;

    public int organ1value = 0, organ2value = 0, organ3value = 0, organ4value = 0, organ5value = 0, organ6value = 0;

    Shop shop;

	// Use this for initialization
	void Start ()
    {
        myImage = transform.GetComponent<Image>();
        shop = FindObjectOfType<Shop>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if im not purchasede
        if (!purchased)
        {
            //if i have money
            if(shop.organ1 >= organ1value && shop.organ2 >= organ2value && shop.organ3 >= organ3value && shop.organ4 >= organ4value && shop.organ5 >= organ5value && shop.organ6 >= organ6value)
            {
                //if i am disabled
                if (!imEnabled)
                {
                    imEnabled = true;
                    Color myColor;
                    myColor = Color.white;
                    myColor.a = 1;
                    myImage.color = myColor;
                }
            }
            else
            {
                //if i am enabled
                if (imEnabled)
                {
                    imEnabled = false;
                    Color myColor;
                    myColor = Color.white;
                    myColor.a = 0.2f;
                    myImage.color = myColor;
                }
            }
        }
        else //if i have already buy this weapon
        {            
            if (!imEnabled)
            {
                imEnabled = true;
                Color myColor;
                myColor = Color.white;
                myColor.a = 1;
                myImage.color = myColor;
            }
        }
	}
}
