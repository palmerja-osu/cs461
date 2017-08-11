
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 4f;

    public int health = 100; //current enemy health


    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.wayPoints[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die(); //if it takes health to zero or less, enemy dies
        }
    }
    
    // kill function if enemy is less than 0
    void Die()
    {
        Destroy(gameObject);
    }



    void Update()
    {
        //vector is x/y/z movement
        //subtract current posisiton to target
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //moving between waypoints
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.wayPoints.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.wayPoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives --;  //-- means minus equal 1
        Destroy(gameObject);
    }


}
