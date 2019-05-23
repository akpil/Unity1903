using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField]
    private Transform leftPos, rightPos;
    private int killCount;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            leftPos = transform.GetChild(0);
            rightPos = transform.GetChild(1);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        killCount = 0;
        BattleUIController.instance.ShowKillCount(killCount);
        StartCoroutine(SpawnRoutine());
    }
    public void AddKillCount()
    {
        killCount++;
        BattleUIController.instance.ShowKillCount(killCount);
    }
    private IEnumerator SpawnRoutine()
    {
        int maleFemale = 0;
        int rightLeft = 0;
        WaitForSeconds waitinTime = new WaitForSeconds(0.7f);
        while (true)
        {
            maleFemale = Random.Range(0, 2);
            rightLeft = Random.Range(0, 2);

            EnemyController enemy = EnemyPool.instance.GetFromPool(maleFemale);
            if (rightLeft == 0)
            {
                enemy.transform.position = leftPos.position;
                enemy.transform.rotation = leftPos.rotation;
            }
            else
            {
                enemy.transform.position = rightPos.position;
                enemy.transform.rotation = rightPos.rotation;
            }
            enemy.SetupData();
            yield return waitinTime;
        }
    }
}
