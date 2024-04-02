using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;
    
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
        Debug.Log("Game Over!");
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
