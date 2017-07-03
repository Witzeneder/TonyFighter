using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerJS : MonoBehaviour
{

    public GameOverMenuJS gameOverMenu;
    public WinMenuJS winMenu;

    public PlayerControllerJS player;
    private Vector3 playerStartPoint;


    //-------------------------------------------------------------------------------------------------------//

    // Use this for initialization
    void Start()
    {

        playerStartPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {                                                                  
        player.gameObject.SetActive(false);                             //set player inactive
        gameOverMenu.gameObject.SetActive(true);                        //show game over menu
    }


    /**
	 * Resets the all game elements so that it can start again from the beginning
	 */
    public void Reset()
    {
        gameOverMenu.gameObject.SetActive(false);
        winMenu.gameObject.SetActive(false);//hide game over menu
        player.transform.position = playerStartPoint;
        player.gameObject.SetActive(true);             
    }

    public void finishGame()
    {
        winMenu.gameObject.SetActive(true);
        
    }



}

