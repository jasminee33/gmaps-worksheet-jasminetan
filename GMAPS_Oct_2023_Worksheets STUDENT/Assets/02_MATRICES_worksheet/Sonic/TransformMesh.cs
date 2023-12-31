﻿//// Uncomment this whole file.

//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }
    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>(); //a reference to MeshManager
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);
        //store the current position of the Sonic sprite
        

        // Move the sprite by (1,1)
        Translate(1, 1);

        Rotate(-45); //rotate by -45 degree
        
    }


    void Translate(float x, float y)
    {
        //Q5b
        transformMatrix.SetIdentity(); 
        transformMatrix.SetTranslationMat(x, y); // translating the sprite based in the parameters
        Transform(); //calls the Transform 

        pos = transformMatrix * pos;
    }

    void Rotate(float angle)
    {
        HMatrix2D toOriginMatrix = new HMatrix2D(); //create matrix for translation 
        HMatrix2D fromOriginMatrix = new HMatrix2D(); //create matrix for translation 
        HMatrix2D rotateMatrix = new HMatrix2D(); //create matrix for rotation

        toOriginMatrix.SetTranslationMat(-pos.x, -pos.y); //translate to origin is negative
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y); //translate back to original position

        rotateMatrix.SetRotationMat(angle); //sets the angle 

        transformMatrix.SetIdentity(); 
        transformMatrix = toOriginMatrix * fromOriginMatrix * rotateMatrix; // calculate the matrix transformation by multiplying


        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            //Q5c
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y); //create a new 2D vector 
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y; //update x and y of the vertex 
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
