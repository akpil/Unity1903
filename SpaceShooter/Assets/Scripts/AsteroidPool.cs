using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    public  AsteroidMovement[] origin;
    private List<AsteroidMovement>[] pool;
    // Start is called before the first frame update
    void Start()
    {
        pool = new List<AsteroidMovement>[origin.Length];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = new List<AsteroidMovement>();
        }
    }

    public AsteroidMovement GetFromPool(int id)
    {
        for (int i = 0; i < pool[id].Count; i++)
        {
            if (!pool[id][i].gameObject.activeInHierarchy)
            {
                pool[id][i].gameObject.SetActive(true);
                return pool[id][i];
            }
        }
        AsteroidMovement newObj = Instantiate(origin[id]);
        pool[id].Add(newObj);
        return newObj;
    }
}
