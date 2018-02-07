using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganScript : MonoBehaviour
{
    [HideInInspector]
    public bool grabberEnabled = false;
    Vector3 playerPosition;
    Rigidbody2D rb;

    bool coroutineStarted = false;

    float timer = 10;

    private void Start()
    {
        playerPosition = GameObject.Find("Character").transform.position;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ResetGravity());
    }

    private void Update()
    {
        if(grabberEnabled == false)
            timer -= Time.deltaTime * 2;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }

        if (!coroutineStarted)
        {
            coroutineStarted = true;
            StartCoroutine(ResetGravity());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("EXIT: " + collider.name);
        
        if (collider.CompareTag("Grabber"))
        {
            rb.gravityScale = 1;
            grabberEnabled = false;
        }
    }

    IEnumerator ResetGravity()
    {
        rb.gravityScale = 1;
        yield return new WaitForSeconds(0.2f);
        coroutineStarted = false;
    }
}
