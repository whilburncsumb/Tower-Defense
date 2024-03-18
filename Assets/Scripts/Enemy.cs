using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private int waypointIndex = 0;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            getNextWayPoint();
        }
    }

    void getNextWayPoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
