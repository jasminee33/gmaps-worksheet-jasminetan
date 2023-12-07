using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    //declare the public variable called Position and Velocity
    public HVector2D Position = new HVector2D(0, 0); 
    public HVector2D Velocity = new HVector2D(0, 0);

    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x; //sets the postion of the x 
        Position.y = transform.position.y; // sets the position of the y 

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size; //to know the  sprite size
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f; // to find the radius needs to be divide by 2
    }

    public bool IsCollidingWith(float x, float y)
    {
        float distance = Util.FindDistance(Position, new HVector2D(x, y)); // calculates the distance using Util.FindDistance that takes in parameter of the balls position and the point at (x,y)
        return distance <= Radius; // calculates of distance is less or equal to the radius 
    }

    public bool IsCollidingWith(Ball2D other)
    {
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        float displacementX = Velocity.x * deltaTime; // calculates the diaplacement of x = velocity of x * time 
        float displacementY = Velocity.y * deltaTime; // calculates the diaplacement of y = velocity of x * time 

        Position.x += Velocity.x * deltaTime; // update the position of x 
        Position.y += Velocity.y * deltaTime; // update the position of y

        transform.position = new Vector2(Position.x, Position.y); // update the postion of (x,y) of thae ball 
    }
}

