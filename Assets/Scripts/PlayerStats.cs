using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public int startingMoney = 400;
    public int startingLives = 20;
    void Start()
    {
        Money = startingMoney;
        Lives = startingLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}