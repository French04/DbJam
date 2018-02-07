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


    void Start()
    {
        instance = this;
        Cursor.SetCursor(aimTexture, new Vector2(aimTexture.width/2, aimTexture.height/2), CursorMode.Auto);
        //GameObject weaponPrefab = Resources.Load("Weapons/Winchester") as GameObject;
        //currentWeapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        seller = GameObject.Find("Seller").GetComponent<ShopEnabler>();
    }


    void Update()
    {
        if (!seller.openShop)
        {
            /*Vector3 pos = transform.position;
            pos.x += 0.5f;
            pos.y += 0.4f;
            currentWeapon.transform.position = pos;*/

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

            /*Vector3 posTemp = (pern.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
            posTemp *= distance;
            IK.transform.position = posTemp;/*                    

            /*Camera.main.WorldToScreenPoint(transform.position);

            Debug.Log(Camera.main.WorldToScreenPoint(transform.position));*/
            //

            if (Input.mousePosition.x > Camera.main.WorldToScreenPoint(transform.position).x - 70)
            {
                IK.transform.position = mousePos;
            }

            if (currentWeapon != null)
            {
                if (Input.GetMouseButton(0))
                {
                    StartCoroutine(currentWeapon.GetComponent<Weapon>().Fire());
                }
                
                if (Input.GetMouseButton(1))
                {
                    grabber.GetComponent<Grabber>().FireGrabber();
                }
            }
        }
    }
}

