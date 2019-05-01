using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

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
        float horizontal = Input.GetAxis("Horizontal");
        Debug.LogFormat("horizontal : {0}", horizontal.ToString());
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(horizontal, 0, vertical) * 10);
        
    }
}
