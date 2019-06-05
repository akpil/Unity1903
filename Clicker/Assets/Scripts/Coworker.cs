using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eCoworkerState
{
    Idle,
    Walk
}

public class Coworker : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform incomePos;

    private eCoworkerState state;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        state = eCoworkerState.Idle;
        StartCoroutine(StateMachine());
        StartCoroutine(MakeIncome());
    }

    private IEnumerator StateMachine()
    {
        WaitForSeconds oneSec = new WaitForSeconds(1);
        while (true)
        {
            switch (state)
            {
                case eCoworkerState.Idle:
                    rb2d.velocity = Vector2.zero;
                    anim.SetBool(AnimHash.Walking, false);
                    break;
                case eCoworkerState.Walk:
                    int i = Random.Range(0, 2);
                    if (i == 1) // left
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    else // right
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    rb2d.velocity = transform.right * -speed;
                    anim.SetBool(AnimHash.Walking, true);
                    break;
            }
            state = (eCoworkerState)Random.Range(0, 2);
            yield return oneSec;
        }
    }

    private IEnumerator MakeIncome()
    {
        WaitForSeconds period = new WaitForSeconds(1);
        while (true)
        {
            yield return period;
            CoworkersController.instance.GainIncome(0, incomePos.position);
        }
    }
}
