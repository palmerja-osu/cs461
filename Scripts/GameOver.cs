using UnityEngine;
using UnityEngine.SceneManagement; //use it when loading a new level

public class GameOver : MonoBehaviour {

  
    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;
    public GameObject ui;

    

    public void Retry()
    {
        //rebuild the current active scene
        Toggle();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); //added scene fader
    }

    public void Menu()
    {
        Debug.Log("Go to menu.");
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
