
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;

    //hide speed
    [HideInInspector]
    public float speed;

    public float health = 100; //current enemy health

    public int worth = 50; //value of monster death

    public GameObject deathEffect; //death animation

    private bool isDead = false;

   
    void Start()
    {
        speed = startSpeed;

    }
    public void TakeDamage(float amount)
    {
        
        health -= amount;
        if(health <= 0 && !isDead)
        {
            Die(); //if it takes health to zero or less, enemy dies
        }
    }
    

    public void  Slow (float amount)
    {
        //startSpeed is never modified
        speed = startSpeed * (1f - amount);
    }



    // kill function if enemy is less than 0
    void Die()
    {

        isDead = true;

        PlayerStats.Money += worth;  //update money when die is active

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f); //death animation

        WaveSpawner.EnemiesAlive--; //subtract 1 from current enemies alive
        
        Destroy(gameObject);
    }


}
