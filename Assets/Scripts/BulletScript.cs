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
        if (name.Contains("Rocket"))
        {
            gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            Destroy(gameObject, 4);
        }
        else if (collision.collider.tag != "Bullet" && destroyOnContact)
        {
            Destroy(gameObject);
        }
    }
}
