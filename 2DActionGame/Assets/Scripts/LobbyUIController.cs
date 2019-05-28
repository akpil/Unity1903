using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LobbyUIController : MonoBehaviour
{
    public static LobbyUIController instance;
    [SerializeField]
    private UIElement[] elementArr;

    [SerializeField]
    private ElementInfo[] infos;
    [SerializeField]
    private Sprite[] elemntIcons;
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
        infos = new ElementInfo[2];
        infos[0] = new ElementInfo();
        infos[0].level = 0;
        infos[0].title = "Power";
        infos[0].contents = "upgrade power from {0} to {1}";
        infos[0].iconID = 0;
        infos[0].valueBase = 1;
        infos[0].valueWeight = 1.01f;
        infos[0].valueCurrent = infos[0].valueBase;
        infos[0].costBase = 10;
        infos[0].costWeight = 1.05f;
        infos[0].costCurrent = infos[0].costBase;

        infos[1] = new ElementInfo();
        infos[1].level = 0;
        infos[1].title = "HP";
        infos[1].contents = "upgrade HP from {0} to {1}";
        infos[1].iconID = 1;
        infos[1].valueBase = 1;
        infos[1].valueWeight = 1.03f;
        infos[1].valueCurrent = infos[0].valueBase;
        infos[1].costBase = 10;
        infos[1].costWeight = 1.05f;
        infos[1].costCurrent = infos[0].costBase;

        for (int i = 0; i < elementArr.Length; i++)
        {
            float nextLevelValue = infos[i].valueBase * Mathf.Pow(infos[i].valueWeight, infos[i].level + 1);
            string contentsString = string.Format(infos[i].contents, infos[i].valueCurrent.ToString("F2"), nextLevelValue.ToString("F2"));
            elementArr[i].InitElement(elemntIcons[infos[i].iconID], infos[i].title, contentsString);
        }
    }

    public void LevelUP(int id, int amount)
    {
        infos[id].level += amount;
        DataClass.instance.elemlevels[id] = infos[id].level;

        infos[id].valueCurrent = infos[id].valueBase * Mathf.Pow(infos[id].valueWeight, infos[id].level);
        infos[id].costCurrent = infos[id].costBase * Mathf.Pow(infos[id].costWeight, infos[id].level);
        float nextLevelValue = infos[id].valueBase * Mathf.Pow(infos[id].valueWeight, infos[id].level + 1);
        string contentsString = string.Format(infos[id].contents, infos[id].valueCurrent.ToString("F2"), nextLevelValue.ToString("F2"));
        elementArr[id].Renew(infos[id].title, contentsString);
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