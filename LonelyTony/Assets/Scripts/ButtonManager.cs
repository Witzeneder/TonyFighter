using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void PlayEndlessButton(string endlessGame)
    {

        SceneManager.LoadScene(endlessGame);
    }

    public void ExitAppButton()
    {
        Application.Quit();
    }
}
