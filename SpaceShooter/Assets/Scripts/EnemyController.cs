using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed;

    public float fireRate;
    public Bolt boltPrefab;
    public Transform boltPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
            Bolt bolt = Instantiate(boltPrefab, boltPos.position, boltPos.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bolt"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
