using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AsteroidMovement[] asteroidPrefab;
    public int AsteroidSpawnCount;
    public float SpawnPosXMin;
    public float SpawnPosXMax;
    public float SpawnPosZ;

    public float SpawnTime;
    private float currentSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpawnTime <= 0)
        {
            for (int i = 0; i < AsteroidSpawnCount; i++)
            {
                AsteroidMovement asteroid =
                Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)]);
                asteroid.transform.position = new Vector3(Random.Range(SpawnPosXMin, SpawnPosXMax),
                                                           0,
                                                           SpawnPosZ);
            }
            AsteroidSpawnCount += 2;
            currentSpawnTime = SpawnTime;
        }
        currentSpawnTime -= Time.deltaTime;
    }
}
