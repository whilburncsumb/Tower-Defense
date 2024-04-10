using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public string nextLevel = "Level2";
    public int levelToUnlock = 2;
    public Camera _camera;
    public Transform loseCameraPos;
    
    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown("e"))////////////////////////////debug////////////////////
        {
            EndGame();
        }
        
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _camera.GetComponent<CameraController>().TriggerCameraTransition(loseCameraPos);
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
