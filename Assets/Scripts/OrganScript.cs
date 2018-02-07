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

    OrganCollector organCollector;

    private void Start()
    {
        organCollector = FindObjectOfType<OrganCollector>();
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
            if (transform.CompareTag("Brain"))
            {
                organCollector.brain += 1;
                Destroy(gameObject);
            }
            else if (transform.CompareTag("Heart"))
            {
                organCollector.heart += 1;
                Destroy(gameObject);
            }
            else if (transform.CompareTag("Intestine"))
            {
                organCollector.intestine += 1;
                Destroy(gameObject);
            }
            else if (transform.CompareTag("Kidney"))
            {
                organCollector.kidney += 1;
                Destroy(gameObject);
            }
            else if (transform.CompareTag("Liver"))
            {
                organCollector.liver += 1;
                Destroy(gameObject);
            }
            else if (transform.CompareTag("Lungs"))
            {
                organCollector.lung += 1;
                Destroy(gameObject);
            }

        }
    }

    IEnumerator ResetGravity()
    {
        rb.gravityScale = 1;
        yield return new WaitForSeconds(0.2f);
        coroutineStarted = false;
    }
}
