using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    //Q1a)
    public float[,] Entries { get; set; } = new float[3, 3]; //creating 3x3 matrix using entries

    public HMatrix2D()
    {
        // your code here
        SetIdentity();
    }

    //public HVector2D(float _x, float _y)
    //{
    //    x = _x;
    //    y = _y;
    //    h = 1.0f;
    //}

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++) //Setting the row 
        {
            for(int x = 0; x < 3; x++) //setting the columns
            {
                Entries[x, y] = multiArray[x, y]; // multiArray to allow for matrix of rows and columns 
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {

        // First row
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second row
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third row
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        //Q2a
        HMatrix2D additionResult = new HMatrix2D();

        for (int y = 0; y < 3; y++) // loops and create rows
            for (int x = 0; x < 3; x++) //loops to create the coloumn 
                additionResult.Entries[y, x] = left.Entries[y, x] + right.Entries[y, x]; // adds the (x,y)
        return additionResult;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D subtractionResult = new HMatrix2D();

        for (int y = 0; y < 3; y++) // loops and create rows
            for (int x = 0; x < 3; x++) //loops to create the coloumn 
                subtractionResult.Entries[y, x] = left.Entries[y, x] - right.Entries[y, x]; //
        return subtractionResult;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D multiplicationResult = new HMatrix2D();

        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                multiplicationResult.Entries[y, x] = left.Entries[y, x] * scalar;
        return multiplicationResult;
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y, //
            left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y //calculate the 

        );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

            /* 
                00 01 02    00 01 02
                10 11 12    10 11 12
                20 21 22    20 21 22
                */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

            //Q2d)
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],
            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]

        // and so on for another 7 entries
    );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        //Q2b)
        for (int row = 0; row < 3; row++) 
            for (int col = 0; col < 3; col++)
                if (left.Entries[row, col] != right.Entries[row, col]) //checks if the matrix elements is not the same 
                    return false; // returns false
        return true; // if it is the same then returns true since the left is == to right
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < 3; row++)
            for (int col = 0; col < 3; col++)
                if (left.Entries[row, col] == right.Entries[row, col]) //checks if the matrix elements is not the same 
                    return true; // returns false
        return false; // if it is the same then returns true since the left is == to right
    }

    //public HMatrix2D transpose()
    //{
    //    return // your code here
    //}

    //public float GetDeterminant()
    //{
    //    return // your code here
    //}

    public void SetIdentity()
    {
        //Q1b)
        //for (int y = 0; y < 3; y++) //since the matrix i 3x3, the matrix must be 0,1,2 which is y<3, starts a loop and for each row to start  
        //{
        //    for (int x = 0; x < 3; x++) // create for each column
        //    {
        //        if (x == y) //if row is equal to column 
        //        {
        //            Entries[y, x] = 1; //the matrix will be 1
        //        }
        //        else
        //        {
        //            Entries[y, x] = 0; // else it will be 0 
        //        }
        //    }
        //}

        //Q1c) ternar operator - variable = (condition) ? expressionTrue : expressionFalse;
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                Entries[y, x] = x == y ? 1 : 0;


    }

    public void SetTranslationMat(float transX, float transY)
    {
        //Q3b
        SetIdentity(); // Start with the identity matrix

        // Set the translation 
        Entries[0, 2] = transX;
        Entries[1, 2] = transY;
    }

    public void SetRotationMat(float rotDeg)
    {
        //Q3a
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad; //converting to radians 

        //Rotation matrix , only x and y axis are being changed
        Entries[0, 0] = Mathf.Cos(rad); // cos0
    Entries[0, 1] = -Mathf.Sin(rad); // -sin0
    Entries[1, 0] = Mathf.Sin(rad);  // sin0
    Entries[1, 1] = Mathf.Cos(rad);  // cos0
    }

    //public void SetScalingMat(float scaleX, float scaleY)
    //{
    //    // your code here
    //}

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
