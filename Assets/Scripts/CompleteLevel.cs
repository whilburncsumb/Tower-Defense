using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLeve : MonoBehaviour
{
    public SceneFader fader;
    public string menuSceneName = "TD Menu";
    public string nextLevel = "Level2";
    public int levelToUnlock = 2;

    public void Continue()
    {
        // Debug.Log("Level complete!");
        PlayerPrefs.SetInt("levelReached",levelToUnlock);
        fader.FadeTo(nextLevel);
    }
    
    public void Menu()
    {
        fader.FadeTo(menuSceneName);
    }

}
