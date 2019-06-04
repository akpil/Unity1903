using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    delegate void VoidDelegate();
    [SerializeField]
    private TouchManager touchManager;
    [SerializeField]
    private GemPool gemPool;

    private double MaxHP;
    private double CurrentHP;
    private float stageHPBase;
    private float stageWeight;
    private int stage;

    private double power;
    private int powerLevel;
    private float powerBase;
    private float powerWeight;

    private int GemID;
    private Gem currentGem;

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

    private void SetNewGameData()
    {
        stageHPBase= 100;
        stageWeight = 1.2f;
        stage = 0;
        CurrentHP = 0;
        MaxHP = stageHPBase * Math.Pow(stageWeight, stage);
        powerLevel = 0;
        powerBase = 1;
        powerWeight = 1.05f;
        power = powerBase * Math.Pow(powerWeight, powerLevel);

        GemID = UnityEngine.Random.Range(0, 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        //touchManager.SetTouchFunction(Touch);
        SetNewGameData();
        currentGem = gemPool.GetFromPool(GemID);
        UIController.instance.ShowProgress((float)(CurrentHP / MaxHP));
    }

    public void Touch()
    {
        CurrentHP += power;
        currentGem.ShowProgress((float)(CurrentHP/ MaxHP));
        UIController.instance.ShowProgress((float)(CurrentHP / MaxHP));
        if (CurrentHP >= MaxHP)
        {
            currentGem.gameObject.SetActive(false);
            stage++;
            CurrentHP = 0;
            MaxHP = stageHPBase * Math.Pow(stageWeight, stage);
            GemID = UnityEngine.Random.Range(0, 3);
            currentGem = gemPool.GetFromPool(GemID);
            UIController.instance.ShowProgress((float)(CurrentHP / MaxHP));
        }

    }
}
