using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

	public string mainMenuLevel;
	public ScoreManager score;
	public InputField input;
	public Text nameField;
	private int actualScore;
	private int actualHighscore;
	public Button submit;
	private string nameEndless;
	public GameObject helper;
	private string highscoreEndless;
	public GameOverHighscore highscoreEntry;


	public void Start() {
		score = FindObjectOfType<ScoreManager> ();
		//highscoreNames = new string[3];
		actualScore = (int)score.scoreCount;
		actualHighscore = (int)score.highscoreCount;
		//Debug.Log (actualScore);
		//Debug.Log (actualHighscore);

		if (actualScore == actualHighscore) {
			Debug.Log (actualScore);
			Debug.Log (actualHighscore);
		}
	}

	public void RestartGame() {
		FindObjectOfType<GameManager> ().Reset ();	// call the reset function of the game manager
	}

	public void BackToMain() {
		SceneManager.LoadScene (mainMenuLevel);


	}

    private void Update()
    {
        score = FindObjectOfType<ScoreManager>();
        //highscoreNames = new string[3];
        actualScore = (int)score.scoreCount;
        actualHighscore = (int)score.highscoreCount;
        //Debug.Log(actualScore);
        //Debug.Log(actualHighscore);

        if (actualScore == actualHighscore)
        {
            highscoreEntry.gameObject.SetActive(true);
        }

    }


}
