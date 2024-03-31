using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneytext;

    // Update is called once per frame
    void Update()
    {
        moneytext.text = "$" + PlayerStats.Money.ToString();
    }
}
