using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickUp : MonoBehaviour {

	public int scoreIncreaser;									//how many points a coin gives

	private ScoreManager myScoreManager;

	// Use this for initialization
	void Start () {
		myScoreManager = FindObjectOfType<ScoreManager> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Player") {
			Debug.Log ("Collected Coin");
			myScoreManager.addCoinScore (scoreIncreaser);		//add the score to the coins
			gameObject.SetActive(false);


		}

	}


}
