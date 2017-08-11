using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded)
            return;


        if (PlayerStats.Lives <= 0)
        {
            //if player lives = 0 then call the end game
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        //game over call here
    }
}
