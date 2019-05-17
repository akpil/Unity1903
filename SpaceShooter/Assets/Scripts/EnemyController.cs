using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed;

    public float fireRate;
    private BoltPool boltPool;
    public Transform boltPos;
    private GameController controller;
    public int KillScore = 10;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetBoltPool(BoltPool pool)
    {
        if (pool != null)
        {
            boltPool = pool;
        }
    }

    private void OnEnable()
    {
        rb.velocity = Vector3.back * Speed;
        StartCoroutine(Fire());
        StartCoroutine(Movement());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator Movement()
    {
        float force, sleepTime;
        force = Random.Range(0, 5);
        sleepTime = Random.Range(0.4f, 1f);
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 1f));
            if (transform.position.x > 0)
            {
                rb.velocity += Vector3.left * force;
            }
            else
            {
                rb.velocity += Vector3.right * force;
            }
            yield return new WaitForSeconds(sleepTime);
            rb.velocity = Vector3.back * Speed;
            yield return new WaitForSeconds(Random.Range(0.2f, 0.7f));
            if (transform.position.x > 0)
            {
                rb.velocity += Vector3.left * force;
            }
            else
            {
                rb.velocity += Vector3.right * force;
            }
            yield return new WaitForSeconds(sleepTime);
            rb.velocity = Vector3.back * Speed;
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            Bolt bolt = boltPool.GetFromPool();
            bolt.transform.position = boltPos.position;
            bolt.transform.rotation = boltPos.rotation;
            SoundController.instance.PlayEffectSound((int)eSoundEffectID.FireEnemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bolt"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Timer effect = EffectPool.instance.GetFromPool((int)eEffectType.EnemyExp);
            effect.transform.position = transform.position;
            SoundController.instance.PlayEffectSound((int)eSoundEffectID.ExpEnemy);
            if (controller == null)
            {
                GameObject a = GameObject.FindGameObjectWithTag("GameController");
                controller = a.GetComponent<GameController>();
            }
            controller.AddScore(KillScore);
        }
    }
}
