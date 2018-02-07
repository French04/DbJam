using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Animator buttonsSlide;
    

	public void PlayPressed()
	{
		bool isPlay = buttonsSlide.GetBool ("isPlay");
		buttonsSlide.SetBool ("isPlay", !isPlay);
		buttonsSlide.SetBool ("isCredits", false);

	}

	public void CreditsPressed()
	{
		bool isCredits = buttonsSlide.GetBool ("isCredits");
		buttonsSlide.SetBool ("isCredits", !isCredits);
		buttonsSlide.SetBool ("isPlay", false);

	}

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int i)
    {
        LevelCounter.currentLevel = i;
        GameManager.JumpToLevel(LevelCounter.currentLevel);
    }

}
