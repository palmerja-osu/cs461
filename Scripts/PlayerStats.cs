using System.Collections;
using UnityEngine;


//player stats go here for money/level/items
public class PlayerStats : MonoBehaviour {

    //careful static carries on from one scene to another
    public static int Money; // being accessable without ref anything in scene
    public int startMoney = 400; //public int = edit this inside of inspector 

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0; //set 0 here to reset rounds when game starts
    }

    
}
