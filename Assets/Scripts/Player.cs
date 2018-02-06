﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Texture2D aimTexture = null;
    public GameObject currentWeapon = null;
    public Transform IK;
    public static Player instance;
    ShopEnabler seller;


    void Start()
    {
        instance = this;
        Cursor.SetCursor(aimTexture, new Vector2(0, 0), CursorMode.Auto);
        //GameObject weaponPrefab = Resources.Load("Weapons/Winchester") as GameObject;
        //currentWeapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        seller = GameObject.Find("Seller").GetComponent<ShopEnabler>();
    }


    void Update()
    {
        if (!seller.openShop)
        {
            Vector3 pos = transform.position;
            pos.x += 0.5f;
            pos.y += 0.4f;
            currentWeapon.transform.position = pos;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(Quaternion.LookRotation(Vector3.forward, mousePos - currentWeapon.transform.position).eulerAngles);

            //float angle = Quaternion.LookRotation(Vector3.forward, mousePos - currentWeapon.transform.position).eulerAngles.z;

            //if (angle < 340 && angle > 190)
            //{
            //currentWeapon.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - currentWeapon.transform.position);
            //}

            /*Vector3 IKPos = IK.transform.position;
            IKPos.y = mousePos.y;
            IK.transform.position = IKPos;*/

            if (Input.mousePosition.x > Camera.main.WorldToScreenPoint(transform.position).x - 70)
            {
                IK.transform.position = mousePos;
            }//

            /*Camera.main.WorldToScreenPoint(transform.position);

            Debug.Log(Camera.main.WorldToScreenPoint(transform.position));*/
            //

            if (currentWeapon != null)
            {
                if (Input.GetMouseButton(0))
                {
                    currentWeapon.GetComponent<Weapon>().Fire();
                }
            }
        }
    }
}

