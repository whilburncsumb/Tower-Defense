using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TDMainMenu : MonoBehaviour
{
    public string levelToLoad;
    public SceneFader fader;

    public void Play()
    {
        fader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
