using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    public float waveSpawnDelay = 0.5f;
    // public TextMeshProUGUI waveCountdownText;
    public Text waveCountdownText;
    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave incoming!");
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(waveSpawnDelay);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    
    
}
