using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIController : MonoBehaviour
{    
    public static BattleUIController instance;

    [SerializeField]
    private Text KillCountText;
    [SerializeField]
    private Image HPGauge;

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

    public void ShowKillCount(int count)
    {
        KillCountText.text = count.ToString();
    }

    public void ShowHP(float currentHP, float maxHP)
    {
        HPGauge.fillAmount = currentHP / maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
