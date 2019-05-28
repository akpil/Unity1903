using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eEnemyState { Idle, Move, Attack, Dead};
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private eEnemyState enemystate;

    [Header("Data")]
    [Range(0, 10)]
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float MaxHP, Atk;
    private float currentHP;

    [SerializeField]
    private Transform hpBarPos;

    private Player target;
    private GameObject targetObj;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        anim.SetBool(AnimHash.Walk, false);
        anim.SetBool(AnimHash.Attack, false);
        anim.SetBool(AnimHash.Dead, false);
    }

    public void SetupData(float _HP = -1)
    {
        if (_HP > 0)
        {
            MaxHP = _HP;
        }        
        currentHP = MaxHP;
        enemystate = eEnemyState.Idle;
        StartCoroutine(EnemyState());
    }

    private IEnumerator EnemyState()
    {
        WaitForSeconds oneSec = new WaitForSeconds(1);
        while (true)
        {
            switch (enemystate)
            {
                case eEnemyState.Idle:
                    anim.SetBool(AnimHash.Walk, false);
                    rb2d.velocity = Vector2.zero;
                    enemystate = eEnemyState.Move;
                    break;
                case eEnemyState.Move:
                    anim.SetBool(AnimHash.Walk, true);
                    rb2d.velocity = transform.right * Speed;
                    enemystate = eEnemyState.Idle;
                    break;
                case eEnemyState.Attack:
                    anim.SetBool(AnimHash.Walk, false);
                    anim.SetBool(AnimHash.Attack, true);
                    rb2d.velocity = Vector2.zero;
                    break;
                case eEnemyState.Dead:
                    break;
            }
            yield return oneSec;
        }
    }

    public void AttackFinish()
    {
        anim.SetBool(AnimHash.Attack, false);
    }

    public void AttackTarget()
    {
        target.Hit(Atk);
        //targetObj.SendMessage("Hit", Atk);
    }

    public void Hit(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            enemystate = eEnemyState.Dead;
            anim.SetBool(AnimHash.Dead, true);
            GameController.instance.AddKillCount();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemystate = eEnemyState.Attack;
            target = collision.gameObject.GetComponent<Player>();
            //targetObj = collision.gameObject;
        }
    }
}
