using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("unity");
        //Debug.LogFormat("{0} // {1}", 1, 10);
        //Debug.LogWarning("unity");
        //Debug.LogError("unity");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Speed;
        float vertical = Input.GetAxis("Vertical") * Speed;
        rb.velocity = new Vector3(horizontal, 0, vertical);        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("pickup  enter");
        }
    }

}
