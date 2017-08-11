using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    //tower fire rate
    public float fireRate = 1f;
    private float fireCountdown = 0f;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    //bullet reference
    public GameObject bulletPreFab;
    public Transform firePoint;

   
//start here
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
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
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (target == null) 
        return;

        Vector3 dir = target.position - transform.position;

        //quaternion is for rotation
        //euler angels is x/y/z angles
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //smooth old rotation to new rotation determined by new turn speed then convert to euler angles
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //set movement only y axes
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        Debug.Log("Before firecountdown");
        //shoot method
        if(fireCountdown <= 0f)
        {
            Debug.Log("inside of shoot loop");
            Shoot();
            fireCountdown = 1f / fireRate;
            InvokeRepeating("Shoot", 1f, 2f);

        }
    }


    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }






    //red range circle
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}