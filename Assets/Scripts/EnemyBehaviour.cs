using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float lifePoints = 10;

    private Rigidbody2D _Rb;
    private bool _CanMove = true;

    private void Awake()
    {
        _Rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_CanMove)
        {
            _Rb.velocity = new Vector2(-movementSpeed, 0);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            var _BulletDmg = Player.instance.currentWeapon.GetComponent<Weapon>().damage;
            lifePoints -= _BulletDmg;
            
            if (lifePoints <= 0)
                Destroy(gameObject);
        }

        if(collision.collider.CompareTag("Civilian"))
        {
            StartCoroutine(KillingCivilian());
            //Play animation killing civilian
            //Play animation civilian dying

        }
    }

    private IEnumerator KillingCivilian()
    {
        _CanMove = false;
        
        yield return new WaitForSeconds(5f); //change waiting value with animation timer
        Destroy(gameObject);
        _CanMove = true;
    }

    private void OnDestroy()
    {
        if (SpawnEnemies.instance.LastEnemiesStanding > 0)
            SpawnEnemies.instance.LastEnemiesStanding--;

        
    }
}
