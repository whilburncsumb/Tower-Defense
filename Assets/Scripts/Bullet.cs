using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Effects;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    public GameObject hitEffect;
    [Header("Stats")]
    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;
    
    public void Seek(GameObject target_)
    {
        this.target = target_;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(this.GameObject());
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target.transform);
    }

    void HitTarget()
    {
        GameObject e = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(e,5f);
        if (explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(this.GameObject());
    }

    void Damage(GameObject enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.GameObject());
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }
}
