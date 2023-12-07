using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCue : MonoBehaviour
{
    public LineFactory lineFactory;
    public GameObject ballObject;

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
            if (ball != null && ball.IsCollidingWith(startLinePos.x, startLinePos.y))  //gets the startLinePos x and y coordinates 
            {
                drawnLine = lineFactory.GetLine(startLinePos, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.3f, Color.black); //calls line factory to make line , starts line drawing  till the mouse psition
                drawnLine.EnableDrawing(true);
            }
        }
        else if (Input.GetMouseButtonUp(0) && drawnLine != null)
        {
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


