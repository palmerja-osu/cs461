using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;

    //time between enemy release
    public float timeBetweenWaves = 3f;
    //time between spawning first wave
    private float countDown = 2f;


    //reference
    public Text waveCountdownText;
    private int waveIndex = 0;


    void Update()
    {
        if (countDown <= 0f)
        {
            //reset time
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        //reduce countdown by 1 every second
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);  //shows number will never be less than 0 or negitive

        //Mathf cuts off all decimals 
        waveCountdownText.text = string.Format("{0:0.00}", countDown);
    }

    //IEnumerator allows for pausing this piece of code before continuing
    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(.5f);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    } 

    //numOfEnemies = waveNumber * waveNumber + 1;

}
