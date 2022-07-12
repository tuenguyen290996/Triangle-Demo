using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerater : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[3];
        int[] triangles = new int[3];

        vertices[0] = new Vector3(-1, -1);
        vertices[1] = new Vector3(-1, 1);
        vertices[2] = new Vector3(1, 1);

        mesh.vertices = vertices;

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
    }

    
}
