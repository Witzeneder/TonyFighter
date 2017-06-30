using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	public string mainMenuLevel;


	public void RestartGame() {
		FindObjectOfType<GameManager> ().Reset ();	// call the reset function of the game manager
	}

	public void BackToMain() {
		SceneManager.LoadScene (mainMenuLevel);


	}


}
