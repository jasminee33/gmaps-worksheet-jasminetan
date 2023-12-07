using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

    //needs to be put into the inspector for the line to work as it calls the Line Factory script and the ball game object
    private Line drawnLine; 
    private Ball2D ball;

    private void Start()
    {
        ball = ballObject.GetComponent<Ball2D>(); 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var startLinePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Start line drawing
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))  //checks if the ball not empty and gets the startLinePos x and y coordinates based on the input of the mouse 
            {
                drawnLine = lineFactory.GetLine(startLinePos, ball.transform.position, 0.3f, Color.black); //calls line factory to make line , starts line drawing  till the mouse position
                drawnLine.EnableDrawing(true); //line is seen as it is active 
            }
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null) 
        {
            //when the mouse is not pressed then it will disable the line
            drawnLine.EnableDrawing(false);

            //update the velocity of the white ball.
            //calculating the direction of the ball ,  sutraction 
            HVector2D v = new HVector2D(ball.Position.x - drawnLine.end.x, ball.Position.y - drawnLine.end.y); // calculate the (ball postion x coordianate) - (line drawn x coordinate) , ((ball postion x coordianate) - (line drawn x coordinate))
            ball.Velocity = v;

            drawnLine = null; // End line drawing            
        }

        if (drawnLine != null)
        {
            drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Update line bsed on end of the mouse 
        }
    }

    /// <summary>
    /// Get a list of active lines and deactivates them.
    /// </summary>
    public void Clear()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }
}


