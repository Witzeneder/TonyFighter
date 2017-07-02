using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour {

	public Text firstname;
	public Text firstpoints;
	private int point1;


	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("endlessFirstPoints")) {
			firstname.text = PlayerPrefs.GetString("endlessFirstName");
			point1 = PlayerPrefs.GetInt ("endlessFirstPoints");
			firstpoints.text = point1.ToString();
		}
			


	
	}
	// Update is called once per frame
	void Update () {
		
	}
}
