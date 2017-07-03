using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManag : MonoBehaviour {

	public PlayerControl player;
	private Vector3 playerStartPoint;
	public GameOver gameOverMenu;
	public WinLava winMenu;

	// Use this for initialization
	void Start () {
		playerStartPoint = player.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGameWin() {
		player.gameObject.SetActive(false);								//set player inactive
		winMenu.gameObject.SetActive(true);
	}

	public void ResetWin() {
		winMenu.gameObject.SetActive (false);
		player.transform.position = playerStartPoint;					//set the player back to the startpoint
		player.gameObject.SetActive(true);								//set player active again

	}


	public void RestartGame() {
		player.gameObject.SetActive(false);								//set player inactive
		gameOverMenu.gameObject.SetActive(true);						//show game over menu

	}

	public void Reset() {
		gameOverMenu.gameObject.SetActive(false);						//hide game over menu
		player.transform.position = playerStartPoint;					//set the player back to the startpoint
		player.gameObject.SetActive(true);								//set player active again
}

}
