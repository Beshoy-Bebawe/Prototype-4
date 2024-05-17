using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9; 
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject[] powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
          int powerupIndex = Random.Range(0 ,powerupPrefab.Length);
         SpawnEnemyWave(waveNumber);
         Instantiate (powerupPrefab[powerupIndex] , GenerateSpawnPosition(), powerupPrefab[powerupIndex].transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyScript>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            int powerupIndex = Random.Range(0 ,powerupPrefab.Length);
            Instantiate(powerupPrefab[powerupIndex],GenerateSpawnPosition(),powerupPrefab[powerupIndex].transform.rotation);
            
        }
        
    }
    private Vector3 GenerateSpawnPosition()
    {
     float spawnPosX = Random.Range(-spawnRange , spawnRange);// the random.range makes a random number genartoer from a a range and the range is classfied as
    float spawnPosZ = Random.Range(-spawnRange ,spawnRange);
    Vector3 randomPos = new Vector3(spawnPosX, 0 , spawnPosZ);
    return randomPos;

    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
         int enemyIndex = Random.Range( 0,enemyPrefabs.Length);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs[enemyIndex] , GenerateSpawnPosition(),enemyPrefabs[enemyIndex].transform.rotation);

        }


    }
}
