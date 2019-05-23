using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool instance;
    public EnemyController[] origin;
    private List<EnemyController>[] pool;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            origin = new EnemyController[2];
            origin[0] = Resources.Load<EnemyController>("Prefab/Enemy");
            origin[1] = Resources.Load<EnemyController>("Prefab/FEnemy");
            //origin = Resources.LoadAll<EnemyController>("Prefab");

            pool = new List<EnemyController>[origin.Length];
            for (int i = 0; i < origin.Length; i++)
            {
                pool[i] = new List<EnemyController>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public EnemyController GetFromPool(int id)
    {
        for (int i = 0; i < pool[id].Count; i++)
        {
            if (!pool[id][i].gameObject.activeInHierarchy)
            {
                pool[id][i].gameObject.SetActive(true);
                return pool[id][i];
            }
        }
        EnemyController newObj = Instantiate(origin[id]);
        pool[id].Add(newObj);
        return newObj;
    }
}
