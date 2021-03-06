﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private float Atk, CurrentHP;
    [SerializeField]
    private float MaxHP;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Init();
    }

    public void Init()
    {
        CurrentHP = MaxHP;
        Atk = 1;
    }

    public void Hit(float damage)
    {
        CurrentHP -= damage;
        BattleUIController.instance.ShowHP(CurrentHP, MaxHP);
        if (CurrentHP <= 0)
        {
            anim.SetBool(AnimHash.Dead, true);
        }        
    }

    public float GetDamage()
    {
        return Atk;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool(AnimHash.Attack, true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool(AnimHash.Attack, false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
}
