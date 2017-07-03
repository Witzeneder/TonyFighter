using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHighEnemy : MonoBehaviour {

	public GameObject helper;
	public ScoreManagEnemy score;
	public InputField input;
	public Text nameField;
	public Button submit;
	private int actualScore;
	private int actualHighscore;
	private string nameEndless;
	private string highscoreEndless;


	public void Start() {

	}


	public void HighscoreBoard(string name) {
		actualScore = (int)score.scoreCount;
		actualHighscore = (int)score.highscoreCount;
		Debug.Log (actualScore);
		Debug.Log (actualHighscore);
		PlayerPrefs.SetInt ("endlessEnemyFirstPoints", actualHighscore);
		PlayerPrefs.SetString ("endlessEnemyFirstName", name);
		input.text = "";
	}



}
