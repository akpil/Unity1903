using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eEnemyState { Idle, Move, Attack, Dead};
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private eEnemyState enemystate;
    private float speed;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 1;
    }

    private void OnEnable()
    {
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
                    rb2d.velocity = transform.right * speed;
                    enemystate = eEnemyState.Idle;
                    break;
            }
            yield return oneSec;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
