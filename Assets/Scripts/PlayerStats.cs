using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public int startingMoney = 400;
    public int startingLives = 20;
    public static int Rounds;
    void Start()
    {
        Money = startingMoney;
        Lives = startingLives;
        Rounds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
