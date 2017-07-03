using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuJS : MonoBehaviour
{

    public string mainMenuLevel;
    private string nameLevel;


    public void Start()
    {
        
    }

    public void RestartGame()
    {
        FindObjectOfType<GameManagerJS>().Reset();    // call the reset function of the game manager
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(mainMenuLevel);


    }

    private void Update()
    {
        

    }


}
