using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : Timer
{
    [SerializeField]
    protected Text textComp;
    public void SetText(string value)
    {
        textComp.text = value;
    }
}
