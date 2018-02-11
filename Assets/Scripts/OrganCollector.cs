using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrganCollector : MonoBehaviour
{
    [HideInInspector]
    public int heart = 0, brain = 0, lung = 0, kidney = 0, intestine = 0, liver = 0;

    public static OrganCollector instance;

    GameObject feedback;
    GameObject pauseButton;
    GameObject shop;

    public Text feedbackHeart, feedbackBrain, feedbackLungs, feedbackKidney, feedbackIntestine, feedbackLiver, civilNumber;

    //public GameObject eventSystem;

    private void Awake()
    {
        shop = GameObject.Find("Shop");


    }


    // Use this for initialization
    void Start ()
    {
        /*//Check if instance already exists
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
        }*/

        feedback = GameObject.Find("FeedBack");
        pauseButton = GameObject.Find("PauseButton");
        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        feedbackHeart.text = "" +heart;
        feedbackBrain.text = "" + brain;
        feedbackLungs.text = "" + lung;
        feedbackKidney.text = "" + kidney;
        feedbackIntestine.text = "" + intestine;
        feedbackLiver.text = "" + liver;
        civilNumber.text = "" + CivilianManager.instance.CiviliansReamins;

        if(CivilianManager.instance.CiviliansReamins <= 1)
        {
            civilNumber.color = Color.red;
        }
        else if(CivilianManager.instance.CiviliansReamins == 2)
        {
            civilNumber.color = Color.yellow;
        }
        else
        {
            civilNumber.color = Color.green;
        }



        if (SceneManager.GetActiveScene().name != "MainMenu")
        {

            feedback.SetActive(true);
            pauseButton.SetActive(true);
            //eventSystem.SetActive(true);
        }
        else
        {
            if (shop != null && feedback != null && pauseButton != null)
            {
                if (shop.activeInHierarchy)
                {
                    shop.SetActive(false);
                }
                feedback.SetActive(false);
                pauseButton.SetActive(false);
            }

            //eventSystem.SetActive(false);
            Destroy(gameObject);
        }
	}
}
