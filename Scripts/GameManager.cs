using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //next wave inc text
    //public Text waveLabel;


    public static bool GameIsOver; 


    public GameObject gameOverUI;

    public GameObject completeLevelUI;




    void Start()
    {
        //to prevent overlay gameover by resetting default to false
        GameIsOver = false;

     

}
    void Update()
    {
        if (GameIsOver)
            return;
/*
        //quick shortcut to end game by pressing e
        //for testing
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
*/

        if (PlayerStats.Lives <= 0)
        {
            //if player lives = 0 then call the end game
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        //game over call here

        //gameover screen active
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
