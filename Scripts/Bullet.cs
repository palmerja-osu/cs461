using UnityEngine;
public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;

    //bullet damage
    public int damage = 50;


    //bullet explosion effect
    public GameObject impactEffect;
    public float explosionRadius = 0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }


    void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //order to look at target
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;


        //length of direction vector <= distance of the frame
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        //haven't hit target, want to move
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target); //look at target

    }

    void HitTarget()
    {


        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f); //deestroy the animation after 5sec

        if (explosionRadius > 0f)
        {
            Explode();
        } 
        else
        {
            Damage(target);
        }


        Destroy(gameObject);
    }

    void Explode()
    {
        //create a layer mask for only hitting the enemies
        Collider[] colliders =  Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")  //check to see if its an enemy
            {
                Damage(collider.transform);  //if hits, damage them
            }
        }
    }

    void Damage (Transform enemy)
    {
        Enemy e = GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    //make a red radius circle
    void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }


}
