using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPool : MonoBehaviour
{
    public Bolt origin;
    private List<Bolt> pool;
    // Start is called before the first frame update
    void Start()
    {
        pool = new List<Bolt>();
    }

    public Bolt GetFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                pool[i].gameObject.SetActive(true);
                return pool[i];
            }
        }
        Bolt newObj = Instantiate(origin);
        pool.Add(newObj);
        return newObj;
    }
}
