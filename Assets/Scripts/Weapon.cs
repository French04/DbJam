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
    float heatLevel = 0;
    Transform bulletSpawn;
    float lastFireTime = 0;
    
    
    void Start()
    {
        bulletSpawn = transform.GetChild(0);
    }


    public void Fire()
    {
        if (Time.time >= lastFireTime + fireRate)
        {
            if (weaponType == WeaponType.OneShot)
            {
                GameObject newBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * firePower);
                Destroy(newBullet, 2);
            }
            else if (weaponType == WeaponType.Spread)
            {
                Vector3[] directions = new Vector3[spreadBulletCount];
                for (int i = 0; i < spreadBulletCount; i++)
                {
                    Vector3 mousePosTemp = Input.mousePosition;

                    float bulletOffset = Random.Range(-spreadWidth, spreadWidth);
                    mousePosTemp.y += bulletOffset;
                    mousePosTemp.x += -bulletOffset;

                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosTemp);
                    Vector3 direction = mousePos - transform.position;
                    GameObject newBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
                    newBullet.GetComponent<Rigidbody2D>().AddForce(direction * firePower);
                    Destroy(newBullet, 2);
                }               
            }
           
            lastFireTime = Time.time;
        }
    }
}
