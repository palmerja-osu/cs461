using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour {

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    public GameObject ui;

    public void Continue()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }


    public void Toggle()
    {
        //incase its enabled, flipped and set inactive and visa versa
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            //timescale is speed which game is running
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
