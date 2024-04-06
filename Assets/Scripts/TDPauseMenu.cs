using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TDPauseMenu : MonoBehaviour
{
    public GameObject UI;
    public SceneFader fader;
    public string menu = "TD Menu";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        UI.SetActive(!UI.activeSelf);
        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
            // Time.fixedDeltaTime = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        fader.FadeTo(menu);
    }
    
}
