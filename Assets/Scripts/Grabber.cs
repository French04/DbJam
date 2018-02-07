using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public float grabPower = 1;
    public Transform bulletSpawn;
    

    public void FireGrabber()
    {
        Debug.Log("USE GRABBER");

        RaycastHit hit;


        //if (Physics2D.Raycast((Vector2)bulletSpawn.transform.position, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), out hit))
        if (Physics.Raycast(bulletSpawn.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletSpawn.transform.position, out hit))
        {
            Debug.Log(hit.collider.tag);

            if (hit.collider.tag == "Lungs" || hit.collider.tag == "Liver" || hit.collider.tag == "Kidney" || hit.collider.tag == "Intestine" || hit.collider.tag == "Heart" || hit.collider.tag == "Brain")
            {
                
            }
        }

        /*GameObject newBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(bulletSpawn.transform.right * grabPower, ForceMode2D.Impulse);
        Destroy(newBullet, bulletPersistence);*/
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(bulletSpawn.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletSpawn.transform.position);
    }
}
