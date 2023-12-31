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
        rb.AddForce(new Vector3(1f,0f, 0f), ForceMode.Impulse); //apply the force once using the ForceMode.Impulse and sets the x,y,z values more specifically so that only the x-axis change.
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position); // show the postion of the ball 
    }
}

