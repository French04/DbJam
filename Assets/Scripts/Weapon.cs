using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    public enum WeaponType { OneShot, Spread, ThreeShots };
    public WeaponType weaponType;
    public GameObject bullet;
    
    public float damage = 1;
    public float firePower = 1;
    public float fireRate = 1;
    public float bulletPersistence = 2;
    public float spreadWidth = 5;
    public int spreadBulletCount = 8;
    public float spreadFrequency = 1000000;
    public float threeShotDifference = 0.1f;
    public float heatIncreaseSpeed = 0.1f;
    public float heatDecreaseSpeed = 0.1f;
    public Transform bulletSpawn;
    [HideInInspector] public float heatLevel = 0;
    float lastFireTime = 0;
    public ParticleSystem effectParticle;
    public AudioClip fireSound;
    private AudioSource audioSource;
	public float volume;
    LineRenderer lineRenderer = null;


    void Start()
    {
        effectParticle = GameObject.Find("WFX_MF 4P RIFLE1").GetComponent<ParticleSystem>(); 
        audioSource = GetComponent<AudioSource>();
        lineRenderer = GetComponent<LineRenderer>();
    }
    

    void Update()
    {
        lineRenderer.SetPosition(0, bulletSpawn.position);
        lineRenderer.SetPosition(1, bulletSpawn.position - bulletSpawn.right * -50);

        if (heatLevel > 100)
        {
            heatLevel = 100;
        }
        else
        {
            if (heatLevel < 0)
            {
                heatLevel = 0;
            }
            else
            {
                heatLevel -= heatDecreaseSpeed * Time.deltaTime;
            }
        }
    }


    public IEnumerator Fire()
    {
        if (Time.time >= lastFireTime + fireRate)
        {
            heatLevel += heatIncreaseSpeed;

            if (heatLevel < 100)
            {
                if (weaponType == WeaponType.OneShot)
                {
                    effectParticle.Play();
                    audioSource.PlayOneShot(fireSound, volume);
                    GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                    newBullet.GetComponent<Rigidbody2D>().AddForce(bulletSpawn.transform.right * firePower, ForceMode2D.Impulse);
                    Destroy(newBullet, bulletPersistence);
                }
                else if (weaponType == WeaponType.Spread)
                {
                    Vector3 mousePosTemp = Input.mousePosition;
                    effectParticle.Play();

                    for (int i = 0; i < spreadBulletCount; i++)
                    {
                        audioSource.PlayOneShot(fireSound, volume);
                        float bulletOffset = Mathf.Sin((float)i * spreadFrequency) * spreadWidth; //Random.Range(-spreadWidth, spreadWidth);
                        mousePosTemp.y += bulletOffset;
                        mousePosTemp.x += -bulletOffset;

                        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosTemp);
                        Vector3 direction = mousePos - transform.position;
                        direction.z = 0;
                        direction /= direction.magnitude;

                        GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddForce(direction * (firePower * Random.Range(0.8f, 1.2f)), ForceMode2D.Impulse);
                        Destroy(newBullet, bulletPersistence);
                    }
                }
                else if (weaponType == WeaponType.ThreeShots)
                {
                    audioSource.PlayOneShot(fireSound, volume);
                    for (int i = 0; i < 3; i++)
                    {
                        effectParticle.Play();
                        GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddForce(bulletSpawn.transform.right * firePower, ForceMode2D.Impulse);
                        Destroy(newBullet, bulletPersistence);
                        lastFireTime = Time.time;
                        yield return new WaitForSeconds(threeShotDifference);
                    }
                }
            }           //insert sounds
          
            lastFireTime = Time.time;
            yield return null;
        }
    }
}
