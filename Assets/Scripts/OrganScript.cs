using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganScript : MonoBehaviour
{
    public bool grabberEnabled = false;
    Vector3 playerPosition;
    //Rigidbody2D rb;


    private void Start()
    {
        playerPosition = GameObject.Find("Character").transform.position;
        //rb = GetComponent<Rigidbody2D>();
    }

    /*private void Update()
    {
        if (grabberEnabled)
        {
            if (transform.position != playerPosition)
            {
                transform.position = Vector3.Lerp(transform.position, playerPosition, 1f * Time.deltaTime);
            }

            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    public void OnMouseOver()
    {
        grabberEnabled = Input.GetMouseButton(1);      
    }

    public void OnMouseExit()
    {
        grabberEnabled = false;
    }*/
}
