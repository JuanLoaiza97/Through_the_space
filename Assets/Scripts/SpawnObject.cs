using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Vector2 rangeTop;
    public Vector2 rangeBot;

    public GameObject[] objects;

    public float timeSpawn;
    public float timeNextSpawn;

    public float timeDifficulty;
    public float timeNextDifficulty;
    public float scaleDifficulty;

    public float[] repeatSpawnRateRange = {4, 6};
    public float[] speedRange = {1, 4};

    void Update()
    {
        timeNextSpawn += Time.deltaTime;
        if (timeNextSpawn > timeSpawn)
        {
            timeNextSpawn = 0;
            SpawnEnemies();
            if (Random.Range(0, 10) < 3) {
                SpawnEnemies();
            }
            repeatSpawnRateRange[0] = repeatSpawnRateRange[0] > 0.2 ? repeatSpawnRateRange[0] - 0.1f : 0.2f;
            repeatSpawnRateRange[1] = repeatSpawnRateRange[1] > 0.2 ? repeatSpawnRateRange[1] - 0.1f : 0.2f;
            timeSpawn = Random.Range(repeatSpawnRateRange[0], repeatSpawnRateRange[1]);
        }

        timeNextDifficulty += Time.deltaTime;
        if (timeNextDifficulty > timeDifficulty)
        {
            timeNextDifficulty = 0;
            speedRange[0] += scaleDifficulty;
            speedRange[1] += scaleDifficulty;
        }
    }

    public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(rangeTop.x, rangeBot.x), 
            Random.Range(rangeTop.y, rangeBot.y)
        );
        GameObject obj = objects[Random.Range(0, objects.Length)];
        obj.GetComponent<Meteor>().speed = Random.Range(speedRange[0], speedRange[1]);
        Instantiate(obj, spawnPosition, gameObject.transform.rotation);
    }
}

