using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffectPool : OBJPool<Timer>
{
    public static TouchEffectPool instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            PoolReset();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
