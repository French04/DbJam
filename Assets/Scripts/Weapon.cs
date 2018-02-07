using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType { OneShot, Spread, OneShot_Heating };
    public WeaponType weaponType;
    public GameObject bullet;
    
    public float damage = 1;
    public float firePower = 1;
    public float fireRate = 1;
    public float spreadWidth = 5;
    public int spreadBulletCount = 8;
    public float spreadFrequency = 1000000;
    public float heatIncreaseSpeed = 0.1f;
    public float heatDecreaseSpeed = 0.1f;
    public Transform bulletSpawn;
    [HideInInspector] public float heatLevel = 0;
    float lastFireTime = 0;
    

    void Update()
    {
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


    public void Fire()
    {
        if (Time.time >= lastFireTime + fireRate)
        {
            heatLevel += heatIncreaseSpeed;
            Debug.Log(heatLevel);

            if (weaponType == WeaponType.OneShot_Heating && heatLevel < 100 || weaponType == WeaponType.OneShot)
            {
                
                GameObject newBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().AddForce(bulletSpawn.transform.right * firePower, ForceMode2D.Impulse);
                Destroy(newBullet, 2);
            }
            else if (weaponType == WeaponType.Spread)
            {
                Vector3 mousePosTemp = Input.mousePosition;

                for (int i = 0; i < spreadBulletCount; i++)
                {
                    float bulletOffset = Mathf.Sin((float)i * spreadFrequency) * spreadWidth; //Random.Range(-spreadWidth, spreadWidth);
                    mousePosTemp.y += bulletOffset;
                    mousePosTemp.x += -bulletOffset;                                

                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosTemp);
                    Vector3 direction = mousePos - transform.position;
                    direction.z = 0;
                    direction /= direction.magnitude;

                    GameObject newBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().AddForce(direction * (firePower * Random.Range(0.8f, 1.2f)), ForceMode2D.Impulse);
                    Destroy(newBullet, 2);
                }           
            }

            
            lastFireTime = Time.time;
        }
    }
}
