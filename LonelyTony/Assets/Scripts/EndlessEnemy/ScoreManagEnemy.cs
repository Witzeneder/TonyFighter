using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagEnemy : MonoBehaviour {

	public Text score;							//score textfield
	public Text highscore;						//highscroe textfield

	public float scoreCount;					//score counter
	public float highscoreCount;				//highscore counter

	public float scorePerSecond;				//how much points per second

	public bool counter;						//player alive = count <--> dead = don't count

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("HighscoreEnemy")) {
			highscoreCount = PlayerPrefs.GetFloat ("HighscoreEnemy");
		}
	}

	// Update is called once per frame
	void Update () {

		if (counter) {

			scoreCount += scorePerSecond * Time.deltaTime;					//Time.dealteTime = the time between the frames

		}

		if (scoreCount > highscoreCount) {
			highscoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighscoreEnemy", highscoreCount);
		}

		score.text = "Score: " + Mathf.Round(scoreCount);				//Mathf.Round -> rounds the number without . digits
		highscore.text = "Highscore: " + Mathf.Round(highscoreCount);
	}

	public void addCoinScore(int increase) {
		scoreCount += increase;
	}
}
