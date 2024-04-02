using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [Header("Stats")] 
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int worth = 50;
    [Header("Other")] 
    public GameObject deathEffect;


    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += worth;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,5f);
        Destroy(this.gameObject);
    }
    
    public void Slow(float slowPercent)
    {
        speed = startSpeed * (1f - slowPercent);
    }
}
