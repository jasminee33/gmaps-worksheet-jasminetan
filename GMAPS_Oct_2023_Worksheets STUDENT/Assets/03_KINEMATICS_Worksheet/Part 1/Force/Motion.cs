using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime; // Time.deltaTime is how  much seconds passes since last frame. ref; https://medium.com/star-gazers/understanding-time-deltatime-6528a8c2b5c8

        //calculate displacement = velocity * time // https://www.1728.org/velocity.gif
        float dx = Velocity.x * dt; 
        float dy = Velocity.y * dt;
        float dz = Velocity.z * dt;

        transform.position += (new Vector3(dx, dy, dz)); //update position and allows me to change the velocity in the inspector
    }
}
