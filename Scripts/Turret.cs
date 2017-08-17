using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy; //enemy component of our target

    [Header("General")]
    public float range = 15f;

    [Header("Use Bullets")]//bullet tower fire rate
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public float slowAmount = .5f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

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
            targetEnemy = nearestEnemy.GetComponent<Enemy>(); //updating target
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
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)  //if enemy is out of of range, cut line renderer
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();  //play and stop keeps the particles that have spawned or stops the particles
                    impactLight.enabled = false;
                }
            }
            return;
        }
        

        LockOnTarget(); //call target lock function

        if (useLaser)
        {
            Laser();
        }
        else
        {

           //Debug.Log("Before firecountdown");
            //shoot method
            if(fireCountdown <= 0f)
            {
               // Debug.Log("inside of shoot loop");
                Shoot();
                fireCountdown = 1f / fireRate;
                
            }
            fireCountdown -= Time.deltaTime;
        }

    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;

        //quaternion is for rotation
        //euler angels is x/y/z angles
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //smooth old rotation to new rotation determined by new turn speed then convert to euler angles
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //set movement only y axes
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {

        //damage enemy
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);
  

        //laser graphic
        if (!lineRenderer.enabled)//only do it once
        {
            lineRenderer.enabled = true;
            impactEffect.Play();  //play and stop keeps the particles that have spawned or stops the particles
            impactLight.enabled = true;
        }
        //set line renderer positions to element 0 and 1
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        //particle laser on enemy contact
        //get shooting direction from position of a - position of be
        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.position = target.position + dir.normalized;  //normalized means reducing length to exactly 1 as well as all other axis'
        impactEffect.transform.rotation = Quaternion.LookRotation(dir); //takes a vector of some direction, and points in (dir)

       
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target, targetEnemy);
    }






    //red range circle
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}