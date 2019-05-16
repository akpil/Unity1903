using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEffectType
{
    AsteroidExp, EnemyExp, PlayerExp
}

public class EffectPool : MonoBehaviour
{
    public static EffectPool instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Timer[] origin;
    private List<Timer>[] pool;
    // Start is called before the first frame update
    void Start()
    {
        pool = new List<Timer>[origin.Length];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = new List<Timer>();
        }
    }

    public Timer GetFromPool(int id)
    {
        for (int i = 0; i < pool[id].Count; i++)
        {
            if (!pool[id][i].gameObject.activeInHierarchy)
            {
                pool[id][i].gameObject.SetActive(true);
                return pool[id][i];
            }
        }
        Timer newObj = Instantiate(origin[id]);
        pool[id].Add(newObj);
        return newObj;
    }
}
