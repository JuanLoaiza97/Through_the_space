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

    [Header("Coins")]
    public GameObject coin;
    public

    private void Update()
    {
        //RF3 Generar enemigos
        timeNextSpawn -= Time.deltaTime;
        if (timeNextSpawn < 0)
        {
            timeNextSpawn = timeSpawn;
            SpawnEnemies();
            SpawnCoin();
            UpDifficulty();
        }

        timeNextDifficulty -= Time.deltaTime;
        if (timeNextDifficulty < 0)
        {
            timeNextDifficulty = timeDifficulty;
            speedRange[0] += scaleDifficulty;
            speedRange[1] += scaleDifficulty;
        }

        //RNF3 Genera los botiquines, calcula de forma aleatoria segun un rango dado en que momento se generara un botiquin
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
        enemy.GetComponent<ProjectileMotion>().speed = Random.Range(speedRange[0], speedRange[1]);
        Instantiate(enemy, spawnPosition, gameObject.transform.rotation);

        // Genera un numero al azar del 0 al 10, y si este es menor a 3 vuelve a generar otro enemigo (30% de probabilidad)
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
        obj.GetComponent<ProjectileMotion>().speed = Random.Range(speedRange[0], speedRange[1]);
        Instantiate(obj, spawnPosition, gameObject.transform.rotation);
    }

    private void SpawnCoin()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRangeTop.x, spawnRangeBot.x),
            Random.Range(spawnRangeTop.y, spawnRangeBot.y)
        );
        coin.GetComponent<ProjectileMotion>().speed = Random.Range(speedRange[0], speedRange[1]);
        Instantiate(coin, spawnPosition, gameObject.transform.rotation);
    }
}

