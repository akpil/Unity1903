using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public BGScroller[] BGs;
    public float BGSpeed = 1;
    public AsteroidPool asteroidPool;
    public EnemyPool enemyPool;
    public int AsteroidSpawnCount, EnemySpawnCount;
    public float SpawnPosXMin;
    public float SpawnPosXMax;
    public float SpawnPosZ;

    private Coroutine SpawnRoutine;

    public float SpawnTime;
    private float currentSpawnTime;
    public int Score;
    public UIController ui;
    public Player player;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRoutine = StartCoroutine(SpawnHazard());
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].SetScrollSpeed(BGSpeed);
        }
        Score = 0;
        isGameOver = false;
        ui.ShowScore(Score);
        ui.ShowMessage("");
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

    public void GameOver()
    {
        ui.ShowMessage("Game over");
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].SetScrollSpeed(0);
        }
        StopCoroutine(SpawnRoutine);
        Invoke("SetGameOverTrue", 5);
    }

    private void SetGameOverTrue()
    {
        isGameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        return;
        isGameOver = false;
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);

        SpawnRoutine = StartCoroutine(SpawnHazard());
        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].SetScrollSpeed(BGSpeed);
        }
        Score = 0;
        ui.ShowScore(Score);
        ui.ShowMessage("");
    }

    public void AddScore(int amount)
    {
        Score += amount;
        ui.ShowScore(Score);
    }

    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
}
