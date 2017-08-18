using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{

    //how many enemies in the scene
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public GameManager gameManager;


    //time between enemy release
    public float timeBetweenWaves = 5f;
    //time between spawning first wave
    private float countDown = 15f;


    //reference
    public Text waveCountdownText;
   // public Text waveSpawnText;
    private int waveIndex = 0;

    //public GameObject ui; //toggle

    //attempt to fix a bug when rotating retry screens
    void Start()
    {
        EnemiesAlive = 0;
    }


    void Update()
    {

     

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countDown <= 0f)
        {
            
            // time
            StartCoroutine(SpawnWave());
            StartCoroutine(SpawnWave2());
            StartCoroutine(SpawnWave3());
            StartCoroutine(SpawnWave4());
            StartCoroutine(SpawnWave5());
            countDown = timeBetweenWaves;
         
            return;
        }
        //reduce countdown by 1 every second
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);  //shows number will never be less than 0 or negitive

        //Mathf cuts off all decimals 
        waveCountdownText.text = string.Format("Wave Timer: {0:0.00}", countDown);



    }

    //IEnumerator allows for pausing this piece of code before continuing
    IEnumerator SpawnWave()
    {

        PlayerStats.Rounds++; //increase round count

        //spawn wave of index wave
        Wave wave = waves[waveIndex];
        


        for (int i = 0; i < wave.count; i++) //first enemy type
        {
            
            SpawnEnemy(wave.enemy);

            yield return new WaitForSeconds(1f / wave.rate);

              

        }
        waveIndex++;
    }

    IEnumerator SpawnWave2()
    {
        int localWaveIndex = waveIndex;
        //spawn wave of index wave
        Wave wave = waves[localWaveIndex];
        


        for (int i = 0; i < wave.count2; i++) //second enemy type
        {


            SpawnEnemy(wave.enemy2);
            yield return new WaitForSeconds(1f / wave.rate2);



        }
        localWaveIndex++;
    }

    IEnumerator SpawnWave3()
    {
        int localWaveIndex = waveIndex;
        //spawn wave of index wave
        Wave wave = waves[localWaveIndex];
       


        for (int i = 0; i < wave.count3; i++) //third enemy type
        {

            SpawnEnemy(wave.enemy3);
            yield return new WaitForSeconds(1f / wave.rate3);

        }
        localWaveIndex++;
    }
    IEnumerator SpawnWave4()
    {
        int localWaveIndex = waveIndex;
        //spawn wave of index wave
        Wave wave = waves[localWaveIndex];



        for (int i = 0; i < wave.count4; i++) //third enemy type
        {

            SpawnEnemy(wave.enemy4);
            yield return new WaitForSeconds(1f / wave.rate4);

        }
        localWaveIndex++;
    }
    IEnumerator SpawnWave5()
    {
        int localWaveIndex = waveIndex;
        //spawn wave of index wave
        Wave wave = waves[localWaveIndex];



        for (int i = 0; i < wave.count5; i++) //third enemy type
        {

            SpawnEnemy(wave.enemy5);
            yield return new WaitForSeconds(1f / wave.rate5);

        }
        localWaveIndex++;
    }

    IEnumerator SpawnWave6()
    {
        int localWaveIndex = waveIndex;
        //spawn wave of index wave
        Wave wave = waves[localWaveIndex];



        for (int i = 0; i < wave.count6; i++) //third enemy type
        {

            SpawnEnemy(wave.enemy6);
            yield return new WaitForSeconds(1f / wave.rate6);

        }
        localWaveIndex++;
    }


    void SpawnEnemy(GameObject enemy)
    {
        if (enemy)
        {

            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            EnemiesAlive++;
        }
        else
        {
            Debug.Log("Enemy is null");
        }

    }
    //void WaveSpawnText()
    //{
    //    Toggle();
    //    waveSpawnText.text = string.Format("Wave Incoming!!"); //wave spawn text


    //}

    //toggle wavespawn text
    //public void Toggle()
    //{
    //    incase its enabled, flipped and set inactive and visa versa
    //    ui.SetActive(!ui.activeSelf);

    //    if (ui.activeSelf)
    //    {
    //        //timescale is speed which game is running
    //        Time.timeScale = 0f;
    //    }
    //    else
    //    {
    //        Time.timeScale = 1f;
    //    }
    //}

}
