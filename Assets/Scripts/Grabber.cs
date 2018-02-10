using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public float grabPower = 1;
    public Transform bulletSpawn;
    public Transform origin;
    public LineRenderer lineRenderer;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }


    public void FireGrabber()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (Input.mousePosition.x > Camera.main.WorldToScreenPoint(transform.position).x + 150)
        {
            lineRenderer.enabled = true;
            //lineRenderer.SetWidth(1, 1);
            lineRenderer.SetPosition(0, bulletSpawn.transform.position);
            lineRenderer.SetPosition(1, bulletSpawn.transform.position - bulletSpawn.transform.right * -30);
        }
        else
        {
            //lineRenderer.SetWidth(0, 0);
            lineRenderer.enabled = false;
        }
        
        RaycastHit2D[] hits = Physics2D.RaycastAll(bulletSpawn.transform.position, (bulletSpawn.transform.position - bulletSpawn.transform.right * -50));

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
                    hit.collider.gameObject.transform.position = Vector3.Lerp(hit.collider.gameObject.transform.position, origin.position, (grabPower / Vector3.Distance(hit.collider.gameObject.transform.position, origin.position)) * Time.deltaTime);
                }
            }
        }
    }
}
