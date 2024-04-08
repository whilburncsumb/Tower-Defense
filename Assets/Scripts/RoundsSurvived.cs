using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;
    
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(.7f);
        while (round<PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();
            
            yield return new WaitForSeconds(.05f);
        }
    }
}
