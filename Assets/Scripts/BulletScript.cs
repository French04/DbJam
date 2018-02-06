using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool destroyOnContact = true;
    public bool realisticBalistic = true;


    void Start()
    {
        if (!realisticBalistic)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Bullet" && destroyOnContact)
        {
            Destroy(gameObject);
        }
    }
}
