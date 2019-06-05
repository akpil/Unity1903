using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffectPool : OBJPool<TextEffect>
{
    public static TextEffectPool instance;
    [SerializeField]
    private Transform Canvas;

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

    protected override TextEffect CreateNewObj(int id)
    {
        TextEffect newEffect = base.CreateNewObj(id);
        newEffect.transform.SetParent(Canvas);
        newEffect.transform.localScale = Vector3.one;
        return newEffect;
    }
}
