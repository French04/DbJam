using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType { OneShot, Spread };
    public WeaponType weaponType;
    public GameObject bullet;
    public float damage = 1;
    public float firePower = 1;
    public float fireRate = 1;
    public float spreadWidth = 5;
    public int spreadBulletCount = 8;
    public float spreadFrequency = 1000000;
    float heatLevel = 0;
    public Transform bulletSpawn;
    float lastFireTime = 0;
    
    
    void Start()
    {
        //bulletSpawn = transform.GetChild(0);
    }


    public void Fire()
    {
        if (Time.time >= lastFireTime + fireRate)
        {
            if (weaponType == WeaponType.OneShot)
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

                    //newBullet.transform.LookAt(mousePos);

                    newBullet.GetComponent<Rigidbody2D>().AddForce(direction * (firePower * Random.Range(0.8f, 1.2f)), ForceMode2D.Impulse);
                    Destroy(newBullet, 2);
                }           
            }
           
            lastFireTime = Time.time;
        }
    }
}
