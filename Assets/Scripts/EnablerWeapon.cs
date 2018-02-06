using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnablerWeapon : MonoBehaviour
{
    bool imEnabled = true;
    Image myImage;
    public int myValue = 0;

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
		if(shop.money < myValue && imEnabled)
        {
            Debug.Log("disabled");
            imEnabled = false;
            Color myColor;
            myColor = Color.white;
            myColor.a = 0.2f;
            myImage.color = myColor;
        }
        else if(shop.money >= myValue && !imEnabled)
        {
            Debug.Log("enabled");
            imEnabled = true;
            Color myColor;
            myColor = Color.white;
            myColor.a = 1;
            myImage.color = myColor;
        }
	}
}
