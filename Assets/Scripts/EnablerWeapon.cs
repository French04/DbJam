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

    [HideInInspector]
    public bool iAmCurrentWeapon = false;

    Image myImage;

    public int heart = 0, brain = 0, lung = 0, kidney = 0, intestine = 0, liver = 0;

    OrganCollector organCollector;

	// Use this for initialization
	void Start ()
    {
        myImage = transform.GetComponent<Image>();
        organCollector = FindObjectOfType<OrganCollector>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if i am not the current weapon
        if (!iAmCurrentWeapon)
        {
            //if im not purchasede
            if (!purchased)
            {
                //if i have money
                if(organCollector.heart >= heart && organCollector.brain >= brain && organCollector.lung >= lung && organCollector.kidney >= kidney && organCollector.intestine >= intestine && organCollector.liver >= liver)
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
                imEnabled = true;
                Color myColor;
                myColor = Color.white;
                myColor.a = 1;
                myImage.color = myColor;
            }
        }
        else
        {
            imEnabled = true;
            Color myColor;
            myColor = Color.green;
            myColor.a = 1;
            myImage.color = myColor;
        }
	}
}
