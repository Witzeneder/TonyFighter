using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void PlayEndlessButton(string endlessGame)
    {

        SceneManager.LoadScene(endlessGame);
    }

    public void LevelButton(string level)
    {

        SceneManager.LoadScene(level);
    }

    public void ExitAppButton()
    {
        Application.Quit();
    }
}
