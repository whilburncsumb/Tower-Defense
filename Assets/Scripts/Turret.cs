using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Turret : MonoBehaviour
{

    private GameObject target;
    
    [Header("General")]
    public float range = 15f;
    public float turnSpeed = 10f;
    [Header("Use Bullets")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;

    [Header("Use Laser")] 
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem muzzleSparks;
    public ParticleSystem hitSparks;
    public GameObject glow1;
    public GameObject glow2;
    private Light light1;
    private Light light2;
    
    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public GameObject partToRotate;
    public GameObject firePoint;
    public GameObject muzzleFlash;
    public GameObject smokePoof;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
        if (useLaser)
        {
            light1 = glow1.GetComponent<Light>();
            light2 = glow2.GetComponent<Light>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser && lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                muzzleSparks.Stop();
                hitSparks.Stop();
                light1.enabled = false;
                light2.enabled = false;
            }
            return;
        }

        TrackTarget();
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
    }

    void Laser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            muzzleSparks.Play();
            hitSparks.Play();
            light1.enabled = true;
            light2.enabled = true;
        }
        
        Vector3 dir = firePoint.transform.position - target.transform.position;
        hitSparks.transform.rotation = Quaternion.LookRotation(dir);
        hitSparks.transform.position = target.transform.position + dir.normalized;
        
        lineRenderer.SetPosition(0,firePoint.transform.position);
        lineRenderer.SetPosition(1,target.transform.position);
    }

    void Shoot()
    {
        if (muzzleFlash != null)
        { 
            GameObject m = Instantiate(muzzleFlash, firePoint.transform.position, firePoint.transform.rotation);
            Destroy(m,5f);
        }

        if (smokePoof != null)
        {
            GameObject s = Instantiate(smokePoof, firePoint.transform.position, firePoint.transform.rotation);
            Destroy(s,5f);
        }
        
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
