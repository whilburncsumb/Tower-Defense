using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Turret : MonoBehaviour
{

    private GameObject target;
    
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public GameObject partToRotate;

    public GameObject bulletPrefab;
    public GameObject firePoint;
    
    
    public float turnSpeed = 10f;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        TrackTarget();
        
        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Bullet script = bullet.GetComponent<Bullet>();
        script.Seek(target);
    }

    private void TrackTarget()
    {
        //Target lock on
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp
            (partToRotate.transform.rotation,lookRotation,Time.deltaTime*turnSpeed).eulerAngles;
        partToRotate.transform.rotation = Quaternion.Euler(0f,rotation.y,0f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
