using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Texture2D aimTexture = null;
    LineRenderer lineRenderer = null;
    public GameObject currentWeapon = null; 
        

    void Start ()
    {
        Cursor.SetCursor(aimTexture, new Vector2(0, 0), CursorMode.Auto);
        lineRenderer = GetComponent<LineRenderer>();

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
