using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	Toggle toggle;

	static bool ticked = true;



	void Start() {
		toggle = GameObject.Find ("ToggleMusic").GetComponent<Toggle> ();

		if (ticked) {
			toggle.isOn = true;
		} else {
			toggle.isOn = false;
		}


	}

	public void ToggleMusicChanged (bool isTicked) {



		if (isTicked) {
			AudioListener.volume = 1;
			ticked = true;
		} else {
			AudioListener.volume = 0;
			ticked = false;
		}

	
	}






	public void GoBackToMain () {
		SceneManager.LoadScene ("menu");
	}



}
