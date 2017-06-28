using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score;					//score textfield
	public Text highscore;				//highscroe textfield

	public float scoreCount;			//score counter
	public float highscoreCount;		//highscore counter

	public float scorePerSecond;		//how much points per second

	public bool counter;				//player alive = count <--> dead = don't count

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("Highscore")) {
			highscoreCount = PlayerPrefs.GetFloat ("Highscore");
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (counter) {

			scoreCount += scorePerSecond * Time.deltaTime;					//Time.dealteTime = the time between the frames

		}

		if (scoreCount > highscoreCount) {
			highscoreCount = scoreCount;
			PlayerPrefs.SetFloat ("Highscore", highscoreCount);
		}

		score.text = "Score: " + Mathf.Round(scoreCount);				//Mathf.Round -> rounds the number without . digits
		highscore.text = "Highscore: " + Mathf.Round(highscoreCount);
	}
}
