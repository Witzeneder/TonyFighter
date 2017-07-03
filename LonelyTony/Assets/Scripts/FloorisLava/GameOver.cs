using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public string mainMenuLevel;

	// Use this for initialization
	void Start () {
		
	}

	public void RestartGame() {
		FindObjectOfType<GameManag> ().Reset ();	// call the reset function of the game manager
	}

	public void BackToMain() {
		SceneManager.LoadScene (mainMenuLevel);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
