using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Wave
{
  //class that contains wave properties

  public string WaveName;
  public int noOfEnemies;
  public GameObject[] typeOfEnemy;
  public float spawnInterval;
}
public class WaveSpawner : MonoBehaviour
{
  
  [SerializeField] Wave[] waves; //an array of wave classes
  [SerializeField] Transform[] spawnPoints;

  public static bool canShoot = false;
  private Wave currentWave;
  private int currentWaveNumber;
  private float nextSpawnTime;
  public GameObject Finishanim;
  public int totalEnemiesinAll;
  private bool canSpawn = true;
  private bool SpawnNextWave = false;
  public bool isFinished = false;
  public GameObject[] totalEnemies;
  
  private void Update()
  {

    currentWave = waves[currentWaveNumber]; //current wave equals that index of current wave number in waves array
    if (SpawnNextWave == true)
    {

      SpawnWave();
    }


    //call spawn wave defined below
    totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    if (SpawnNextWave == true && totalEnemies.Length == 0 && !canSpawn && currentWaveNumber + 1 != waves.Length)
    {

      currentWaveNumber++;
      canSpawn = true;
    }
    if (totalEnemiesinAll == 0)
    {

      isFinished = true;
      Finish();

    }




  }
 
  void Finish()
  {

    Finishanim.SetActive(true);

  }
  void Start()
  {
    SpawnNextWave = true;
    foreach (Wave wave in waves)
    {
      totalEnemiesinAll += wave.noOfEnemies;
    }
  }
  public void SpawnFirstWave()
  {

    SpawnNextWave = true;

  }

  //checks if enemies can spawn and if so spawns them if not it waits for the spawnInterval
  void SpawnWave()
  {
    if (canSpawn && nextSpawnTime < Time.time)
    {
      GameObject randomEnemy = currentWave.typeOfEnemy[Random.Range(0, currentWave.typeOfEnemy.Length)];
      Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
      Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
      currentWave.noOfEnemies--;
      nextSpawnTime = Time.time + currentWave.spawnInterval; //resets spawn time to the current waves spawn interval
      if (currentWave.noOfEnemies == 0)
      {

        canSpawn = false; //if total no of enemies have spawned then stop spawning
      }
    }

  }
  public void enemyKilled()
  {
    totalEnemiesinAll -= 1;
  }
}
