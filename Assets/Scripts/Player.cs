using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Texture2D aimTexture = null;
    public GameObject currentWeapon = null;
    public static Player instance;
        

    void Start ()
    {
        instance = this;
        Cursor.SetCursor(aimTexture, new Vector2(0, 0), CursorMode.Auto);
        GameObject weaponPrefab = Resources.Load("Weapons/Winchester") as GameObject;
        currentWeapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
    }
	
	
	void Update ()
    {
        Vector3 pos = transform.position;
        pos.x += 0.5f;
        pos.y += 0.4f;
        currentWeapon.transform.position = pos;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos - currentWeapon.transform.position);

        currentWeapon.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - currentWeapon.transform.position);

        if (currentWeapon != null)
        {
            if (Input.GetMouseButton(0))
            {
                currentWeapon.GetComponent<Weapon>().Fire();
            }
        }
    }   
}
