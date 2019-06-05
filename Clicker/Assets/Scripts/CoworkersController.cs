using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoworkersController : MonoBehaviour
{
    public static CoworkersController instance;

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
        
    }

    public void GainIncome(int id, Vector3 worldPos)
    {
        // id check;
        TextEffect effect = TextEffectPool.instance.GetFromPool(0);
        effect.SetText(100.ToString());
        effect.transform.position = worldPos;

        // add income to gamecontroller
    }
}
