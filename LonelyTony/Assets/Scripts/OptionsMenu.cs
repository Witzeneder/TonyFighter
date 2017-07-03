using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {



	public void ToggleMusicChanged (bool isTicked) {

		if (isTicked) {
			AudioListener.volume = 1;
		} else {
			AudioListener.volume = 0;
		}

	}




	public void GoBackToMain () {
		SceneManager.LoadScene ("menu");
	}



}
