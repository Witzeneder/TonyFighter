using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

	public string mainMenuLevel;
	public ScoreManager score;
	private InputField input;
	private Dictionary<string,float> highscoreBoard;
	private string[] topScorer;
	private int actualScore;
	public string[] highscoreNames;
	private string first;
	private string second;
	private string third;


	public void Start() {
		input = GameObject.Find ("InputField").GetComponent<InputField>();
		score = FindObjectOfType<ScoreManager> ();
		highscoreNames = new string[3];
	}


	public void getHighscoreBoard(string name) {
		Debug.Log (name);
		actualScore = (int)score.scoreCount;
		PlayerPrefs.SetInt (name, actualScore);
		int i = PlayerPrefs.GetInt (name);
		Debug.Log (i);



		if (first == null) {
			first = name;
			PlayerPrefs.SetInt (name, actualScore);
		} else {
			if (PlayerPrefs.GetInt (first) >= actualScore) {
				if (second == null) {
					second = name;
					PlayerPrefs.SetInt (name, actualScore);
				} else { // second != null
					if (PlayerPrefs.GetInt (second) >= actualScore) {
						if (third == null) {
							third = name;
							PlayerPrefs.SetInt (name, actualScore);
						} else {
							if (PlayerPrefs.GetInt (third) < actualScore) {
								third = name;
								PlayerPrefs.SetInt (name, actualScore);
							}
						}
					} else {// names[1] < actualScore
						third = second;
						second = name;
						PlayerPrefs.SetInt (name, actualScore);
					}
				}
			} else {//names[0] < actualScore
				if (second != null) {
					third = second;
				}
				second = first;
				first = name;
				PlayerPrefs.SetInt (name, actualScore);
			}


		}

		PlayerPrefs.SetString ("first", first);
		PlayerPrefs.SetString ("second", second);
		PlayerPrefs.SetString ("third", third);



//		if (highscoreNames [0] == null) {
//			highscoreNames [0] = name;
//		} else {
//			if (PlayerPrefs.GetInt (highscoreNames [0]) >= actualScore) {
//				if (highscoreNames [1] == null) {
//					highscoreNames [1] = name;
//				} else { // names[1] != null
//					if (PlayerPrefs.GetInt (highscoreNames [1]) >= actualScore) {
//						if (highscoreNames [2] == null) {
//							highscoreNames [2] = name;
//						} else {
//							if (PlayerPrefs.GetInt(highscoreNames [2]) < actualScore) {
//								highscoreNames [2] = name;
//							}
//						}
//					} else {// names[1] < actualScore
//						highscoreNames [2] = highscoreNames [1];
//						highscoreNames [1] = name;
//					}
//				}
//			} else {//names[0] < actualScore
//				if (highscoreNames [1] != null) {
//					highscoreNames [2] = highscoreNames [1];
//				}
//				highscoreNames [1] = highscoreNames [0];
//				highscoreNames [0] = name;
//			}
//		}

		//PlayerPrefsX.SetStringArray ("HighscoreNames", highscoreNames);

	}//end getHighscoreBoard

	public void RestartGame() {
		FindObjectOfType<GameManager> ().Reset ();	// call the reset function of the game manager
		input.text = "";
	}

	public void BackToMain() {
		SceneManager.LoadScene (mainMenuLevel);
		input.text = "";


	}


}
