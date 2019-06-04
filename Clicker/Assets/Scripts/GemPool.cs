using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPool : OBJPool<Gem>
{
    private void Awake()
    {
        originArr = Resources.LoadAll<Gem>("Gem");
        PoolReset();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
