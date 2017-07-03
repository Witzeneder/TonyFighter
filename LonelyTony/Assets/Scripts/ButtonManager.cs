using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void PlayEndlessButton(string endlessGame)
    {

        SceneManager.LoadScene(endlessGame);
    }

	public void showHighscore(string highscore)
	{

		SceneManager.LoadScene (highscore);
	}

	public void HighscoreBack(string menu)
	{

		SceneManager.LoadScene (menu);
	}

    public void LevelButton(string level)
    {

        SceneManager.LoadScene(level);
    }

	public void OptionsButton(string options) 
	{
		SceneManager.LoadScene(options);
	}

    public void ExitAppButton()
    {
        Application.Quit();
    }
}
