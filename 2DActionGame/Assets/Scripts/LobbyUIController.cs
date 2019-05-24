using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LobbyUIController : MonoBehaviour
{
    [SerializeField]
    private UIElement[] elementArr;

    [SerializeField]
    private ElementInfo[] infos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class ElementInfo
{
    public int level;    
    public string title;
    public string contents;
    public int iconID;

    public float valueCurrent;
    public float valueWeight;
    public float valueBase;

    public float costCurrent;
    public float costWeight;
    public float costBase;
}