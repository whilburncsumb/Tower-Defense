using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class enemyMovement : MonoBehaviour
{
    private int waypointIndex = 0;
    private Transform target;
    private Enemy _enemy;
    void Start()
    {
        target = Waypoints.waypoints[0];
        _enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * _enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            getNextWayPoint();
        }

        _enemy.speed = _enemy.startSpeed;
    }

    void getNextWayPoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length-1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
