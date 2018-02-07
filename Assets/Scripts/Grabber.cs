using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public float grabPower = 1;
    public Transform bulletSpawn;
    

    public void FireGrabber()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        RaycastHit2D[] hits = Physics2D.RaycastAll(bulletSpawn.transform.position, (Vector2)(mousePos - bulletSpawn.transform.position) * 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.tag == "Lungs" || hit.collider.tag == "Liver" || hit.collider.tag == "Kidney" || hit.collider.tag == "Intestine" || hit.collider.tag == "Heart" || hit.collider.tag == "Brain")
                {
                    Rigidbody2D rbOrgan = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    rbOrgan.gravityScale = 0;
                    rbOrgan.velocity = Vector2.zero;

                    hit.collider.gameObject.GetComponent<OrganScript>().grabberEnabled = true;
                    hit.collider.gameObject.transform.position = Vector3.Lerp(hit.collider.gameObject.transform.position, transform.position, grabPower * Time.deltaTime);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Gizmos.DrawRay(bulletSpawn.transform.position, (mousePos - bulletSpawn.transform.position) * 10);
    }
}
