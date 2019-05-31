using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    protected T[] originArr;
    protected List<T>[] pool;

    public void PoolReset()
    {
        pool = new List<T>[originArr.Length];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = new List<T>();
        }
    }

    protected virtual T CreateNewObj(int id)
    {
        T newObj = Instantiate(originArr[id]);
        pool[id].Add(newObj);
        return newObj;
    }

    public T GetFromPool(int id)
    {
        for (int i = 0; i < pool[id].Count; i++)
        {
            if (!pool[id][i].gameObject.activeInHierarchy)
            {
                pool[id][i].gameObject.SetActive(true);
                return pool[id][i];
            }
        }
        return CreateNewObj(id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
