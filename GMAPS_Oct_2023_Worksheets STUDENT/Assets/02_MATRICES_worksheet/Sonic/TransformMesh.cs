//// Uncomment this whole file.

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

        Rotate(-45);
        
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
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D();
        HMatrix2D rotateMatrix = new HMatrix2D();

        toOriginMatrix.SetTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y);

        rotateMatrix.SetRotationMat(angle);

        transformMatrix.SetIdentity();
        transformMatrix = toOriginMatrix * fromOriginMatrix * rotateMatrix;


        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            //Q5c
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y; //update x and
        }

        meshManager.clonedMesh.vertices = vertices;
    }
}
