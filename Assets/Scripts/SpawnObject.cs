using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    [Header("Spawn config")]

    public float durationLevel;
    public int lanesTotal;
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
    public int probabilitySpawnOtherEnemy;

    [Header("Aids")]
    public GameObject aid;
    public List<float> aidsToSpawn;

    [Header("Coins")]
    public GameObject coin;
    public int coinsTotal;
    public float[] rateSpawnCoin;
    public float timeSpawnCoin;
    public float count;

    private float[] lanesSpawn;
    private Vector3 lastLaneSpawn;
    private void Start()
    {
        timeNextSpawn = timeSpawn;

        //Configuración de generacion de botiquines
        aidsToSpawn.Add(Random.Range(durationLevel * 0.25f, durationLevel * 0.45f));
        aidsToSpawn.Add(Random.Range(durationLevel * 0.55f, durationLevel * 0.95f));

        //Configuración de generacion de monedas
        float rateSpawnCoin = durationLevel / coinsTotal;
        float[] rangeSpawnCoin = new float[2];
        rangeSpawnCoin[0] = rateSpawnCoin * 0.8f;
        rangeSpawnCoin[1] = rateSpawnCoin * 1.1f;
        this.rateSpawnCoin = rangeSpawnCoin;
        timeSpawnCoin = rateSpawnCoin;

        //Configuración de carriles
        lanesSpawn = new float[lanesTotal];
        float laneSize = (spawnRangeTop.y - spawnRangeBot.y) / lanesTotal;
        for (int i = 0; i < lanesTotal; i++)
        {
            if (i == 0)
            {
                lanesSpawn[i] = spawnRangeTop.y - (laneSize / 2);
                continue;
            }
            lanesSpawn[i] = lanesSpawn[i-1] - laneSize;
        }
    }

    private void Update()
    {
        //RF3 Generar enemigos
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
            if (probabilitySpawnOtherEnemy <= 5)
            {
                probabilitySpawnOtherEnemy += 1;
            }
        }

        //RNF3 Genera los botiquines, calcula de forma aleatoria segun un rango dado en que momento se generara un botiquin
        time += Time.deltaTime;
        if (aidsToSpawn.Count > 0 && aidsToSpawn[0] <= time)
        {
            SpawnAids();
        }

        if (time >= timeSpawnCoin && coinsTotal > 0)
        {
            SpawnCoin();
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
        GameObject enemy = enemies[Random.Range(0, enemies.Length)];
        SpawnObj(enemy);

        // Genera un numero al azar del 0 al 10, y si este es menor a 3 vuelve a generar otro enemigo (30% de probabilidad)
        if (Random.Range(0, 10) < probabilitySpawnOtherEnemy)
        {
            SpawnEnemies();
        }
    }


    private void SpawnAids()
    {
        SpawnObj(aid);
        aidsToSpawn.RemoveAt(0);
    }

    private void SpawnCoin()
    {
        SpawnObj(coin);
        coinsTotal--;
        timeSpawnCoin += Random.Range(rateSpawnCoin[0], rateSpawnCoin[1]);
    }

    private void SpawnObj(GameObject obj)
    {
        Vector3 spawnPosition;
        do
        {
            spawnPosition = new Vector3(
                Random.Range(spawnRangeTop.x, spawnRangeBot.x),
                lanesSpawn[Random.Range(0, lanesSpawn.Length)]
            );
        } while (lastLaneSpawn != null && lastLaneSpawn == spawnPosition);

        lastLaneSpawn = spawnPosition;
        obj.GetComponent<ProjectileMotion>().speed = Random.Range(speedRange[0], speedRange[1]);
        Instantiate(obj, spawnPosition, Quaternion.identity);
    }
}

