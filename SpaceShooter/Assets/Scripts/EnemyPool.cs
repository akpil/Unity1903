using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public EnemyController origin;
    public BoltPool enemyBoltPool;
    private List<EnemyController> pool;
    // Start is called before the first frame update
    void Start()
    {
        pool = new List<EnemyController>();
    }

    public EnemyController GetFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                pool[i].gameObject.SetActive(true);
                return pool[i];
            }
        }
        EnemyController newObj = Instantiate(origin);
        newObj.SetBoltPool(enemyBoltPool);
        pool.Add(newObj);
        return newObj;
    }
}
