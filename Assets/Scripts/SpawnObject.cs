using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    [Header("Spawn config")]
    public Vector2 spawnRangeTop;
    public Vector2 spawnRangeBot;
    public float time;
    public float timeSpawn;
    public float timeNextSpawn;
    public float[] repeatSpawnRateRange;
    public float[] speedRange;

    [Header("Enemies")]
    public GameObject[] enemies;
    public float timeDifficulty;
    public float timeNextDifficulty;
    public float scaleDifficulty;

    [Header("Aids")]
    public GameObject[] aids;
    public float aidsInvoked;
    public float timeSpawnAid;
    private void Start()
    {
        timeNextSpawn = timeSpawn;
        timeSpawnAid = Random.Range(15, 30);
    }

    private void Update()
    {
        timeNextSpawn -= Time.deltaTime;
        if (timeNextSpawn < 0)
        {
            timeNextSpawn = timeSpawn;
            SpawnEnemies();
            UpDifficulty();
        }

        timeNextDifficulty -= Time.deltaTime;
        if (timeNextDifficulty < 0)
        {
            timeNextDifficulty = timeDifficulty;
            speedRange[0] += scaleDifficulty;
            speedRange[1] += scaleDifficulty;
        }

        time += Time.deltaTime;
        if (timeSpawnAid <= time && aidsInvoked < 2) {
            SpawnAids();
            timeSpawnAid = Random.Range(35, 60);
            aidsInvoked++;
        }
    }

    private void UpDifficulty()
    {
        repeatSpawnRateRange[0] = repeatSpawnRateRange[0] > 0.2 ? repeatSpawnRateRange[0] - 0.1f : 0.2f;
        repeatSpawnRateRange[1] = repeatSpawnRateRange[1] > 0.2 ? repeatSpawnRateRange[1] - 0.1f : 0.2f;
        timeSpawn = Random.Range(repeatSpawnRateRange[0], repeatSpawnRateRange[1]);
    }

    private void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRangeTop.x, spawnRangeBot.x),
            Random.Range(spawnRangeTop.y, spawnRangeBot.y)
        );
        GameObject enemy = enemies[Random.Range(0, enemies.Length)];
        enemy.GetComponent<EnemyObject>().speed = Random.Range(speedRange[0], speedRange[1]);
        Instantiate(enemy, spawnPosition, gameObject.transform.rotation);

        if (Random.Range(0, 10) < 3)
        {
            SpawnEnemies();
        }
    }


    private void SpawnAids()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRangeTop.x, spawnRangeBot.x),
            Random.Range(spawnRangeTop.y, spawnRangeBot.y)
        );
        GameObject obj = aids[Random.Range(0, aids.Length)];
        obj.GetComponent<FirstAidKit>().speed = Random.Range(speedRange[0], speedRange[1]);
        Instantiate(obj, spawnPosition, gameObject.transform.rotation);
    }
}

