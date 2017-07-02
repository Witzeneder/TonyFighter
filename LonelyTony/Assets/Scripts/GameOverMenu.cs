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



		if (PlayerPrefs.GetString("first") == null) {
			PlayerPrefs.SetString ("first", name);
			PlayerPrefs.SetInt (name, actualScore);
		} else {
			if (PlayerPrefs.GetInt (PlayerPrefs.GetString("first")) >= actualScore) {
				if (PlayerPrefs.GetString("second") == null) {
					PlayerPrefs.SetString ("second", name);
					PlayerPrefs.SetInt (name, actualScore);
				} else { // second != null
					if (PlayerPrefs.GetInt (PlayerPrefs.GetString("second")) >= actualScore) {
						if (PlayerPrefs.GetString("third") == null) {
							PlayerPrefs.SetString("third", name);
							PlayerPrefs.SetInt (name, actualScore);
						} else {
							if (PlayerPrefs.GetInt (PlayerPrefs.GetString("third")) < actualScore) {
								PlayerPrefs.SetString("third", name);
								PlayerPrefs.SetInt (name, actualScore);
							}
						}
					} else {// names[1] < actualScore
						PlayerPrefs.SetString("third", PlayerPrefs.GetString("second"));	//third = second;
						PlayerPrefs.SetString("second", name);								//second = name;
						PlayerPrefs.SetInt (name, actualScore);
					}
				}
			} else {//names[0] < actualScore
				if (PlayerPrefs.GetString("second") != null) {
					PlayerPrefs.SetString("third", PlayerPrefs.GetString("second"));		//third = second;
				}
				PlayerPrefs.SetString("second", PlayerPrefs.GetString("first"));			//second = first;
				PlayerPrefs.SetString("third", name);										//first = name;
				PlayerPrefs.SetInt (name, actualScore);
			}


		}

//		PlayerPrefs.SetString ("first", first);
//		PlayerPrefs.SetString ("second", second);
//		PlayerPrefs.SetString ("third", third);
		Debug.Log(PlayerPrefs.GetInt(PlayerPrefs.GetString("first")));



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
