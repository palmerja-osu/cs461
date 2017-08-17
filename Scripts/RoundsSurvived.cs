using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour {

    public Text roundsText;

    //when the game is done
    void OnEnable()
    {
        StartCoroutine(AnimateText()); //convert to string to view
    }

    IEnumerator AnimateText()
    {

        //display round text is zero
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);

        while (round < PlayerStats.Rounds)
        {
            round++; //increase round count
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f); 
        }
    }

}
