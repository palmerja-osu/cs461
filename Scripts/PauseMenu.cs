using UnityEngine;
using UnityEngine.SceneManagement; //needed to reload an existing scene

public class PauseMenu : MonoBehaviour {

    public GameObject ui;

    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
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

    public void Retry()
    {
        //unfreeze time when reloading
        Toggle();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  same thing below
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); //added the scene fader
    }

    public void Menu()
    {
        Debug.Log("Go To Menu");
        Toggle(); //disable the hangup
        sceneFader.FadeTo(menuSceneName); //added the scene fader
        //SceneManager.LoadScene(menuSceneName);
    }


}
