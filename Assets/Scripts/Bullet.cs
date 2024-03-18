using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    public GameObject hitEffect;

    public float speed = 70f;
    // Start is called before the first frame update
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
    }

    void HitTarget()
    {
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(target.GameObject());
        Destroy(this.GameObject());
    }
}
