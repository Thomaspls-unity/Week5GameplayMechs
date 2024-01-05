using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;
    public float speed;
    public int enemyCount;
    public int waveNumber = 1;

    public GameObject[] powerUpPrefabs;
    public Rigidbody[] enemyPrefabs;
    private float spawnRange = 9;

    private float startDelay = 2;
    private float spawnInterval = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();

        SpawnEnemy(waveNumber);

        Instantiate(powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)], GenerateSpawnPos(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<FightingEnemy>().Length;
        if (enemyCount == 0 )
        {
            waveNumber++;
            SpawnEnemy(waveNumber);

            Instantiate(powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)], GenerateSpawnPos(), Quaternion.identity);
        }
    }

    public void SpawnEnemy(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++) 
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            Rigidbody enemyRb = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], GenerateSpawnPos(), player.transform.rotation);
            enemyRb.AddForce(lookDirection * speed);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
