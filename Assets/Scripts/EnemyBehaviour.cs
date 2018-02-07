using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float lifePoints = 10;

    private Rigidbody2D _Rb;
    private bool _CanMove = true;
    private string _EnemyName;

    GameObject[] organ = new GameObject[6];

    bool coroutineStarted = false;

    private void Awake()
    {
        _Rb = GetComponent<Rigidbody2D>();
        _EnemyName = gameObject.name;

        for (int i = 0; i < organ.Length; i++)
        {
            organ[i] = transform.GetChild(i).gameObject;
            //organ[i].SetActive(false);
        }
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
            

            if (lifePoints <= 0 && coroutineStarted == false)
            {
                coroutineStarted = true;
                _CanMove = false;
                DropOrgans(_EnemyName);
            }        
            else if (lifePoints > 0)
            {
                lifePoints -= _BulletDmg;
            }
        }

        if(collision.collider.CompareTag("Civilian"))
        {
            //StartCoroutine(KillingCivilian());
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
    }

    private void DropOrgans(string enemyName)
    {
        if (enemyName.Contains("Flying"))
        {
            if (_EnemyName.Contains("V2"))
            {
                //drop 4
                StartCoroutine(SpawnOrgan(4));
            }
            else if (_EnemyName.Contains("V3"))
            {
                //drop 5
                StartCoroutine(SpawnOrgan(5));
            }
            else
            {
                //drop 3
                StartCoroutine(SpawnOrgan(3));
            }
        }
        else if (enemyName.Contains("Heavy"))
        {

            if (_EnemyName.Contains("V2"))
            {
                //drop 5
                StartCoroutine(SpawnOrgan(5));
            }
            else if (_EnemyName.Contains("V3"))
            {
                //drop 6
                StartCoroutine(SpawnOrgan(6));
            }
            else
            {
                //drop 4
                StartCoroutine(SpawnOrgan(4));
            }
        }
        else if (enemyName.Contains("Light"))
        {

            if (_EnemyName.Contains("V2"))
            {
                //drop 3
                StartCoroutine(SpawnOrgan(3));
            }
            else if (_EnemyName.Contains("V3"))
            {
                //drop 4
                StartCoroutine(SpawnOrgan(4));
            }
            else
            {
                //drop 2
                StartCoroutine(SpawnOrgan(2));
            }
        }
        else if (enemyName.Contains("Boss"))
        {

            if (_EnemyName.Contains("V2"))
            {
                //drop 25
                StartCoroutine(SpawnOrgan(25));
            }
            else if (_EnemyName.Contains("V3"))
            {
                //drop 30
                StartCoroutine(SpawnOrgan(30));
            }
            else
            {
                //drop 20
                StartCoroutine(SpawnOrgan(20));
            }
        }
    }

    IEnumerator SpawnOrgan(int maxDrop)
    {
        for (int i = 0; i < maxDrop; i++)
        {
            int random = Random.Range(0, 100);
            int randomforceX = Random.Range(-500, 500);
            int randomforceY = Random.Range(300, 500);

            if (random >= 0 && random < 5)
            {
                Debug.Log("instanzio1");
                GameObject SpawnedOrgan = Instantiate(organ[0], transform.position, Quaternion.identity);
                SpawnedOrgan.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomforceX, randomforceY));
            }
            else if(random >= 5 && random < 15)
            {
                Debug.Log("instanzio2");
                GameObject SpawnedOrgan = Instantiate(organ[1], transform.position, Quaternion.identity);
                SpawnedOrgan.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomforceX, randomforceY));
            }
            else if(random >= 15 && random < 30)
            {
                Debug.Log("instanzio3");
                GameObject SpawnedOrgan = Instantiate(organ[2], transform.position, Quaternion.identity);
                SpawnedOrgan.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomforceX, randomforceY));
            }
            else if(random >= 30 && random < 50)
            {
                Debug.Log("instanzio4");
                GameObject SpawnedOrgan = Instantiate(organ[3], transform.position, Quaternion.identity);
                SpawnedOrgan.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomforceX, randomforceY));
            }
            else if(random >= 50 && random < 75)
            {
                Debug.Log("instanzio5");
                GameObject SpawnedOrgan = Instantiate(organ[4], transform.position, Quaternion.identity);
                SpawnedOrgan.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomforceX, randomforceY));
            }
            else if(random >= 75 && random < 100)
            {
                Debug.Log("instanzio6");
                GameObject SpawnedOrgan = Instantiate(organ[5], transform.position, Quaternion.identity);
                SpawnedOrgan.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomforceX, randomforceY));
            }
            yield return null;
        }
        Destroy(gameObject);
    }
}
