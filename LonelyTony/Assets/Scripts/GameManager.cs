using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameOverMenu gameOverMenu;

	public Transform platGenerator;						//starting point of the Platforms			
	private Vector3 platformStartPoint;					//vector of the starting player starting point

	public PlayerController player;						//starting point of the Platforms
	private Vector3 playerStartPoint;					//vector of the starting platform starting point

	//public Transform backround;
	//private Vector3 backroundStartPoint;

	private PlatformDestroyer[] generatedPlatforms;		//the array to store all platforms the programm has generated

	private ScoreManager scoreManager;					//for the scoreCounter

	//-------------------------------------------------------------------------------------------------------//

	// Use this for initialization
	void Start () {
		platformStartPoint = platGenerator.position;
		playerStartPoint = player.transform.position;
		//backroundStartPoint = backround.transform.position;

		scoreManager = FindObjectOfType<ScoreManager> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void RestartGame() {
		scoreManager.counter = false;									//don't count the score anymore when dead
		player.gameObject.SetActive(false);								//set player inactive
		gameOverMenu.gameObject.SetActive(true);						//show game over menu
	}


	/**
	 * Resets the all game elements so that it can start again from the beginning
	 */
	public void Reset() {
		gameOverMenu.gameObject.SetActive(false);						//hide game over menu

		generatedPlatforms = FindObjectsOfType<PlatformDestroyer>();
		for (int i = 0; i < generatedPlatforms.Length; i++) {
			generatedPlatforms[i].gameObject.SetActive(false);			//make the object disappear
		}//end for

		player.transform.position = playerStartPoint;					//set the player back to the startpoint
		platGenerator.position = platformStartPoint;					//set the platformgen to the start 
		//backround.transform.position = backroundStartPoint;
		player.gameObject.SetActive(true);								//set player active again

		scoreManager.scoreCount = 0;									//set score back to 0
		scoreManager.counter = true;									//start counting again
	}



}

