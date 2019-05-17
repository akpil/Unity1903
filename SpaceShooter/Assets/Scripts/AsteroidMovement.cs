using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed;
    public float Tumble;
    private GameController controller;
    public int KillScore = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * Speed;
    }
    private void OnEnable()
    {
        rb.angularVelocity = Random.insideUnitSphere * Tumble;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    private void OnDisable()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bolt"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Timer effect = EffectPool.instance.GetFromPool((int)eEffectType.AsteroidExp);
            effect.transform.position = transform.position;
            SoundController.instance.PlayEffectSound((int)eSoundEffectID.ExpAst);
            if (controller == null)
            {
                GameObject a = GameObject.FindGameObjectWithTag("GameController");
                controller = a.GetComponent<GameController>();
            }
            controller.AddScore(KillScore);
        }
    }
    
}
