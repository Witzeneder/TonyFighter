using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


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
		StartCoroutine ("RestartGameCoroutine");		// start coroutine by its name
	}

	/*
	 * This coroutine is being used to restart the game smoothly after gameover
	 * --> make the player invisible
	 * --> add some time delay so that the game does not restart immediately
	 * --> make player visible again
	 */
	public IEnumerator RestartGameCoroutine() {

		scoreManager.counter = false;									//don't count the score anymore when dead
		player.gameObject.SetActive(false);								//set player inactive
		yield return new WaitForSeconds(0.5f);							//wait half a second
		generatedPlatforms = FindObjectsOfType<PlatformDestroyer>();
		for (int i = 0; i < generatedPlatforms.Length; i++) {
			generatedPlatforms[i].gameObject.SetActive(false);			//make the object disappear
		}//end for

		player.transform.position = playerStartPoint;					//set the player back to the startpoint
		platGenerator.position = platformStartPoint;					//set the platformgen to the start 
		//backround.transform.position = backroundStartPoint;
		player.gameObject.SetActive(true);								//set player active again

		scoreManager.scoreCount = 0;									//set score back to 0
		scoreManager.counter = true;									//start to count again


	}
}

