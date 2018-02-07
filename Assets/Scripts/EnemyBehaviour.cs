using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float lifePoints = 10;

    private Rigidbody2D _Rb;
    private bool _CanMove = true;
    private string _EnemyName;

    private void Awake()
    {
        _Rb = GetComponent<Rigidbody2D>();
        _EnemyName = gameObject.name;
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
        //Destroy(gameObject);
        //_CanMove = true;
    }

    private void OnDestroy()
    {
        if (SpawnEnemies.instance.LastEnemiesStanding > 0)
            SpawnEnemies.instance.LastEnemiesStanding--;

        DropOrgans(_EnemyName);

    }

    private void DropOrgans(string enemyName)
    {
        if (enemyName.Contains("Flying"))
        {

            if (_EnemyName.Contains("V2"))
            {
                //drop 4
            }
            else if (_EnemyName.Contains("V3"))
            {
                //drop 5
            }
            else
            {
                //drop 3
            }
        }
        else if (enemyName.Contains("Heavy"))
        {

            if (_EnemyName.Contains("V2"))
            {
                //drop 5
            }
            else if (_EnemyName.Contains("V3"))
            {
                //drop 6
            }
            else
            {
                //drop 4
            }
        }
        else if (enemyName.Contains("Light"))
        {

            if (_EnemyName.Contains("V2"))
            {
                //drop 3
            }
            else if (_EnemyName.Contains("V3"))
            {
                //drop 4
            }
            else
            {
                //drop 2
            }
        }
        else if (enemyName.Contains("Boss"))
        {

            if (_EnemyName.Contains("V2"))
            {
                //drop 25
            }
            else if (_EnemyName.Contains("V3"))
            {
                //drop 30
            }
            else
            {
                //drop 20
            }
        }
    }
}
