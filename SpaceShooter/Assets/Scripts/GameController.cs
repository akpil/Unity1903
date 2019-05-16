using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AsteroidPool asteroidPool;
    public EnemyPool enemyPool;
    public int AsteroidSpawnCount, EnemySpawnCount;
    public float SpawnPosXMin;
    public float SpawnPosXMax;
    public float SpawnPosZ;

    public float SpawnTime;
    private float currentSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHazard());
    }

    private IEnumerator SpawnHazard()
    {
        int asteroidCount = AsteroidSpawnCount;
        int enemyCount = EnemySpawnCount;
        int rand;
        while (true)
        {
            while (asteroidCount > 0 && enemyCount > 0)
            {
                rand = Random.Range(0, 100);
                Debug.Log(rand);
                if (rand < 65) // Asteroid
                {
                    asteroidCount--;
                    AsteroidMovement asteroid = asteroidPool.GetFromPool(Random.Range(0, 3));
                    asteroid.transform.position = new Vector3(Random.Range(SpawnPosXMin, SpawnPosXMax),
                                                               0,
                                                               SpawnPosZ);
                }
                else // enemy
                {
                    enemyCount--;
                    EnemyController enemy = enemyPool.GetFromPool();
                    enemy.transform.position = new Vector3(Random.Range(SpawnPosXMin, SpawnPosXMax),
                                                               0,
                                                               SpawnPosZ);
                }
                yield return new WaitForSeconds(SpawnTime);
            }
            if (asteroidCount > 0)
            {
                for (int i = 0; i < asteroidCount; i++)
                {
                    AsteroidMovement asteroid = asteroidPool.GetFromPool(Random.Range(0, 3));
                    asteroid.transform.position = new Vector3(Random.Range(SpawnPosXMin, SpawnPosXMax),
                                                               0,
                                                               SpawnPosZ);
                    yield return new WaitForSeconds(SpawnTime);
                }
            }
            else
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    EnemyController enemy = enemyPool.GetFromPool();
                    enemy.transform.position = new Vector3(Random.Range(SpawnPosXMin, SpawnPosXMax),
                                                               0,
                                                               SpawnPosZ);
                    yield return new WaitForSeconds(SpawnTime);
                }
            }

            yield return new WaitForSeconds(5);
            asteroidCount = AsteroidSpawnCount;
            enemyCount = EnemySpawnCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
