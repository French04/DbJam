using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseFeedback : MonoBehaviour
{
    public Image leftClick, rightClick;

	// Use this for initialization
	void Start ()
    {
        leftClick = transform.GetChild(0).GetComponent<Image>();
        rightClick = transform.GetChild(1).GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            leftClick.color = Color.black;
        }
        else
        {
            leftClick.color = Color.white;
        }

        if (Input.GetMouseButton(1))
        {
            rightClick.color = Color.black;
        }
        else
        {
            rightClick.color = Color.white;
        }
	}
}
