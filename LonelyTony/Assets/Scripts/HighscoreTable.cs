using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour {

	public Text firstname;
	public Text secondname;
	public Text thirdname;
	public Text firstpoint;
	public Text secondpoint;
	public Text thirdpoint;
	public int first;
	public int second;
	public int third;
	private string[] highscoreNames;


	// Use this for initialization
	void Start () {
//		highscoreNames = PlayerPrefsX.GetStringArray ("HighscoreNames");
//		firstname.text = highscoreNames [0];
//		firstpoint.text = "" + PlayerPrefs.GetInt (highscoreNames [0]);
//		secondname.text = highscoreNames [1];
//		secondpoint.text = "" + PlayerPrefs.GetInt (highscoreNames [1]);
//		thirdname.text = highscoreNames [2];
//		thirdpoint.text = "" + PlayerPrefs.GetInt (highscoreNames [2]);

		firstname.text = PlayerPrefs.GetString ("first");
		secondname.text = PlayerPrefs.GetString ("second");
		thirdname.text = PlayerPrefs.GetString ("third");

		if(PlayerPrefs.HasKey("first")) {
			first = PlayerPrefs.GetInt(PlayerPrefs.GetString("first"));
			firstpoint.text = first.ToString();
		}
		if(PlayerPrefs.HasKey("second")) {
			second = PlayerPrefs.GetInt(PlayerPrefs.GetString("second"));
			secondpoint.text = second.ToString();
		}
		if(PlayerPrefs.HasKey("third")) {
			third = PlayerPrefs.GetInt(PlayerPrefs.GetString("third"));
			thirdpoint.text = third.ToString();
		}
			

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
