using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHighscore : MonoBehaviour {
	
	public GameObject helper;
	public ScoreManager score;
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
			Debug.Log (name);
			Debug.Log (actualScore);
			Debug.Log (actualHighscore);
			PlayerPrefs.SetInt ("endlessFirstPoints", actualHighscore);
			PlayerPrefs.SetString ("endlessFirstName", name);
			input.text = "";
			}



}

