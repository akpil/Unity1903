using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 rewindVector;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rewindVector = new Vector3(0, 0, 40.96f);
    }

    public void SetScrollSpeed(float Speed)
    {
        rb.velocity = Vector3.back * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bumper"))
        {
            transform.position += rewindVector;
        }
    }
}
