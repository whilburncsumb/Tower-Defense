using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public Text roundsText;

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
        Animation anim = GetComponent<Animation>();
        anim.Play();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("TODO: Go to menu");
    }
}
