using UnityEngine;
using UnityEngine.UI; //using ui
using UnityEngine.SceneManagement;  //to change scenes
using System.Collections; //using coroutiens

public class SceneFader : MonoBehaviour
{

    public Image img;
    public AnimationCurve curve;

    void Start()
    {

        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene)); //pass scene
    }

    //IEnmerator controls skipping a frame or controlling seconds
    IEnumerator FadeIn()
    {
        float t = 1f; //animate 1 to zero

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);  //animate the curve
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;  //yield waits until the next frame
        }

        //Load a scene here
    }

    //fade the scene out
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f) //opposite of above
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);  //input specified scene 
    }
}
