using System;
using UnityEngine;
using System.Collections;
using System.Net;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public Transform endPoint;
    public static Transform destination;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    [SerializeField]
    private int waveIndex = 0;
    public Text waveCountdownText;
    public GameLogic gameLogic;

    private void Start()
    {
        destination = endPoint;
    }

    private void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameLogic.WinLevel();
            this.enabled = false;
        }
        
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];
        enemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1/wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject e = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    
}
