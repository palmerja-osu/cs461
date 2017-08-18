using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Tutorial : MonoBehaviour {



    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";


    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
