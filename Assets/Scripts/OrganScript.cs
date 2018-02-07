using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganScript : MonoBehaviour
{
    public bool grabberEnabled = false;
    Vector3 playerPosition;
    Rigidbody2D rb;

    float timer = 5;

    private void Start()
    {
        playerPosition = GameObject.Find("Character").transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        timer = 5;
    }

    private void Update()
    {
        /*if (grabberEnabled)
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
        }*/

        timer -= Time.deltaTime * 2;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*public void OnMouseOver()
    {
        grabberEnabled = Input.GetMouseButton(1);      
    }

    public void OnMouseExit()
    {
        grabberEnabled = false;
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grabber"))
        {
            rb.gravityScale = 1;
        }
    }
}
