using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AsteroidMovement[] asteroidPrefab;
    public EnemyController enemyPrefab;
    public int AsteroidSpawnCount;
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
        while (true)
        {
            for (int i = 0; i < AsteroidSpawnCount; i++)
            {
                AsteroidMovement asteroid =
                Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)]);
                asteroid.transform.position = new Vector3(Random.Range(SpawnPosXMin, SpawnPosXMax),
                                                           0,
                                                           SpawnPosZ);
                yield return new WaitForSeconds(SpawnTime);
            }
            for (int i = 0; i < 3; i++)
            {
                EnemyController enemy = Instantiate(enemyPrefab);
                enemy.transform.position = new Vector3(Random.Range(SpawnPosXMin, SpawnPosXMax),
                                                           0,
                                                           SpawnPosZ);
                yield return new WaitForSeconds(SpawnTime);
            }
            yield return new WaitForSeconds(5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
