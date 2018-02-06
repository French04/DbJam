using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool _DestroyOnCollision = true;


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.tag != "Bullet" && _DestroyOnCollision )
            Destroy(gameObject);
    }

}
