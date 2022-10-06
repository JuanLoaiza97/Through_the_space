using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Transform yRangeTop;
    public Transform yRangeBot;

    public GameObject[] enemies;

    public float timeSpawn = 1;
    public float repeatSpawnRate = 3;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
    }

    void Update()
    {
        repeatSpawnRate = Random.Range(2, 6);
    }

    public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(yRangeTop.position.x, yRangeBot.position.x), 
            Random.Range(yRangeTop.position.y, yRangeBot.position.y)
            );
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPosition, gameObject.transform.rotation);
    }
}
