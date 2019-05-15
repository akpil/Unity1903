using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed;
    public float Tilt;
    public float xMin, xMax, zMin, zMax;
    public BoltPool boltPool;
    public Transform boltPos;
    public float FireRateBase;
    private float FireRateCurrent;
    // Start is called before the first frame update
    void Start()
    {
        FireRateCurrent = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontal, 0, vertical) * Speed;

        rb.rotation = Quaternion.Euler(0, 0, -horizontal * Tilt);

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax),
                                  rb.position.y,
                                  Mathf.Clamp(rb.position.z, zMin, zMax));

        if (Input.GetButton("Fire1") && FireRateCurrent <= 0)
        {
            Bolt newBolt = boltPool.GetFromPool();
            newBolt.transform.position = boltPos.position;
            FireRateCurrent = FireRateBase;
        }
        FireRateCurrent -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);

            // game over
            Debug.Log("game over");
        }
    }
}
