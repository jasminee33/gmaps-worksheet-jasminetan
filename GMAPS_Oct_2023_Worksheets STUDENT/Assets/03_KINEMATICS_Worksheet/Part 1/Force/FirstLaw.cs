using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // get rigidbody
        rb.AddForce(new Vector3(1f,0f, 0f), ForceMode.Impulse); 
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

