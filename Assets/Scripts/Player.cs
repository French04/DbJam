using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Texture2D aimTexture = null;
    public Texture2D cursorTexture = null;
    public GameObject currentWeapon = null;
    public GameObject grabber = null;
    public Transform IK;
    public static Player instance;
    Grabber grabberScript;


    void Start()
    {
        instance = this;
        grabberScript = grabber.GetComponent<Grabber>();

        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width/2, cursorTexture.height/2), CursorMode.Auto);
        Cursor.visible = false;
    }


    void Update()
    {
        grabberScript.lineRenderer.enabled = false;

        if (!ShopEnabler.instance.IsShopOpen && !Pause.instance.IsMenuOpen && !GameManager.IsGameOver)
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

