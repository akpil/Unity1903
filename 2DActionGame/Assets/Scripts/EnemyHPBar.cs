using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    [SerializeField]
    private Image Gauge;
    private void OnEnable()
    {
        Gauge.fillAmount = 1;
    }

    public void ShowGauge(float current, float max)
    {
        Gauge.fillAmount = current / max;

    }
}
