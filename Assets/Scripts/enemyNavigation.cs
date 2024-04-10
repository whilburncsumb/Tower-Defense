using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class enemyNavigation : MonoBehaviour
{
    private Enemy _enemy;
    [HideInInspector]
    public Transform destination;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _enemy = GetComponent<Enemy>();
        destination = WaveSpawner.destination;
    }

    void Update()
    {
        if (_enemy.isDead)
        {
            return;
        }
        if (Vector3.Distance(_enemy.transform.position, destination.position) <= 2f)
        {
            EndPath();
            return;
        }
        agent.SetDestination(destination.position);
        agent.speed = _enemy.speed;
        _enemy.speed = _enemy.startSpeed;
        // Freeze rotation
        _enemy.transform.rotation = Quaternion.identity;
    }

    void EndPath()
    {
        _enemy.isDead = true;
        PlayerStats.Lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}