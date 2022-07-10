using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[3];

        vertices[0] = new Vector3(-1, -1);
        vertices[1] = new Vector3(-1, 1);
        vertices[2] = new Vector3(1, 1);

        mesh.vertices = vertices;

        mesh.triangles = new int[] { 0, 1, 2 };

        GetComponent<MeshFilter>().mesh = mesh;
    }

}
