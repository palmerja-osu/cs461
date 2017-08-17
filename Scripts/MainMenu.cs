using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    //loading the main level
    public string levelToLoad = "MainLevel";

    public SceneFader sceneFader;

    public void Play()
    {
        //Debug.Break();
        sceneFader.FadeTo(levelToLoad);
        //SceneManager.LoadScene("MainLevel");
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

}