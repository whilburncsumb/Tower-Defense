using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [Header("Stats")] 
    public float startSpeed = 10f;
    public float startHealth = 100;
    public int worth = 50;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    private float health;
    [Header("Other")] 
    public GameObject deathEffect;
    public Image healthBar;
    [HideInInspector]
    public bool isDead = false;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health/startHealth;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        PlayerStats.Money += worth;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,5f);
        Destroy(this.gameObject);
        WaveSpawner.enemiesAlive--;
    }
    
    public void Slow(float slowPercent)
    {
        speed = startSpeed * (1f - slowPercent);
    }
}
