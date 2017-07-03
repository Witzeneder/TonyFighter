using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour {

	public Text firstname;
	public Text firstpoints;
	private float point1;
	private string name;
	public ScoreManager score;


	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("Highscore")) {
			name = PlayerPrefs.GetString ("endlessFirstName");
			firstname.text = name;
			//firstname.text = PlayerPrefs.GetString("endlessFirstName");
			point1 = PlayerPrefs.GetFloat ("Highscore");
			firstpoints.text = "" + Mathf.Round(point1);
		}
			


	
	}
	// Update is called once per frame
	void Update () {
		
	}
}
