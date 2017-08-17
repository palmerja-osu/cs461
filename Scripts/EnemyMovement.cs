using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;
    private Enemy speed;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.wayPoints[0];
    }
    void Update()
    {
        //vector is x/y/z movement
        //subtract current posisiton to target
        Vector3 dir = target.position - transform.position;
        transform.forward = dir.normalized;  //attempt to look forward
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        //moving between waypoints
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        //if laser turret isn't targeting enemy, reset enemy speed
        enemy.speed = enemy.startSpeed;

    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.wayPoints.Length - 1)
        {
            EndPath();
            return;
        }

       

        wavepointIndex++;
        target = Waypoints.wayPoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;  //-- means minus equal 1
        WaveSpawner.EnemiesAlive--; //keep track of enemies in scene
        Destroy(gameObject);
    }


}
