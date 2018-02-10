using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Texture2D aimTexture = null;
    public GameObject currentWeapon = null;
    public GameObject grabber = null;
    public Transform IK;
    public static Player instance;
    ShopEnabler seller;
    public Transform pern;
    Grabber grabberScript;


    void Start()
    {
        instance = this;
        seller = GameObject.Find("Seller").GetComponent<ShopEnabler>();
        grabberScript = grabber.GetComponent<Grabber>();
        Cursor.visible = false;
    }


    void Update()
    {
        grabberScript.lineRenderer.enabled = false;

        if (!seller.openShop)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           
            if (Input.mousePosition.x > Camera.main.WorldToScreenPoint(transform.position).x - 50)
            {
                IK.transform.position = mousePos;

                if (currentWeapon != null)
                {
                    if (Input.GetMouseButton(0))
                    {
                        StartCoroutine(currentWeapon.GetComponent<Weapon>().Fire());
                    }
                    else if (Input.GetMouseButton(1))
                    {
                        grabberScript.FireGrabber();
                    }
                }
            }
        }
    }
}

