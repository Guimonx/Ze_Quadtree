using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material;
    int pos = 1;
    private GameObject square;

    public Quad(Material material)
    {
     
        this.material = material;
  

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(0, 0, 0); // Vértice inferior esquerdo
        vertices[1] = new Vector3(pos, 0, 0); // Vértice inferior direito
        vertices[2] = new Vector3(0, 0, pos); // Vértice superior esquerdo
        vertices[3] = new Vector3(pos, 0, pos); // Vértice superior direito
       


        // Criar os triângulos
        int[] triangles = new int[6];
        triangles[0] = 2;
        triangles[1] = 1;
        triangles[2] = 0;
        triangles[3] = 3;
        triangles[4] = 1;
        triangles[5] = 2;


        square = new GameObject("Square");
        square.AddComponent<MeshFilter>();
        square.AddComponent<MeshRenderer>();


        MeshRenderer meshRenderer = square.GetComponent<MeshRenderer>();
        meshRenderer.material = material;


        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;


        mesh.RecalculateNormals();
        MeshFilter meshFilter = square.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        //square.transform.position = new Vector3(1, 0, y);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
