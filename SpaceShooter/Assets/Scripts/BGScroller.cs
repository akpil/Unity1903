using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed = 1;
    private Vector3 rewindVector;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * Speed;
        rewindVector = new Vector3(0, 0, 40.96f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bumper"))
        {
            transform.position += rewindVector;
        }
    }
}
