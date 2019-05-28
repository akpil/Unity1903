using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataClass : MonoBehaviour
{
    public static DataClass instance;
    public int[] elemlevels = new int[2];
    [SerializeField]
    private GameObject a;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
