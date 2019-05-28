using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarPool : MonoBehaviour
{
    [SerializeField]
    private RectTransform canvas;
    public static HPBarPool instance;
    [SerializeField]
    private EnemyHPBar origin;
    private List<EnemyHPBar> pool;

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

    // Start is called before the first frame update
    void Start()
    {
        pool = new List<EnemyHPBar>();
    }

    public EnemyHPBar GetFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                pool[i].gameObject.SetActive(true);
                return pool[i];
            }
        }
        //EnemyHPBar newObj = Instantiate(origin);
        //newObj.transform.SetParent(canvas);
        //newObj.transform.localScale = Vector3.one;
        EnemyHPBar newObj = Instantiate(origin, canvas);
        pool.Add(newObj);
        return newObj;
    }
}
