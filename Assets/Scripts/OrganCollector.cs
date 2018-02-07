﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrganCollector : MonoBehaviour
{
    [HideInInspector]
    public int heart = 0, brain = 0, lung = 0, kidney = 0, intestine = 0, liver = 0;

    public static OrganCollector instance;

    GameObject feedback;

    // Use this for initialization
    void Start ()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        feedback = GameObject.Find("FeedBack");
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(SceneManager.GetActiveScene().name != "Main Menu")
        {
            feedback.SetActive(true);
        }
        else
        {
            feedback.SetActive(false);
        }
	}
}
