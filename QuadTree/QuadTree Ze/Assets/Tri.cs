using UnityEngine;

public class Tri : MonoBehaviour
{
    public float sideLength = 1f; // Comprimento do lado do quadrado
    public Material material; // Material para os triângulos

    void Start()
    {
        GenerateSquare();
    }

    void GenerateSquare()
    {
        // Criar os vértices dos triângulos
        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(0f, 0f, 0f); // Vértice inferior esquerdo
        vertices[1] = new Vector3(sideLength, 0f, 0f); // Vértice inferior direito
        vertices[2] = new Vector3(0f, sideLength, 0f); // Vértice superior esquerdo
        vertices[3] = new Vector3(sideLength, sideLength, 0f); // Vértice superior direito

        // Criar os triângulos
        int[] triangles = new int[6];
        triangles[0] = 0; // Primeiro triângulo: vértices 0, 1, 2
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2; // Segundo triângulo: vértices 2, 1, 3
        triangles[4] = 1;
        triangles[5] = 3;

        // Criar o objeto e adicionar os componentes necessários
        GameObject square = new GameObject("Square");
        square.AddComponent<MeshFilter>();
        square.AddComponent<MeshRenderer>();

        // Atribuir o material aos triângulos
        MeshRenderer meshRenderer = square.GetComponent<MeshRenderer>();
        meshRenderer.material = material;

        // Criar o Mesh e atribuir os vértices e triângulos
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Atualizar a normal dos triângulos (para cálculo da iluminação)
        mesh.RecalculateNormals();

        // Atribuir o Mesh ao filtro de Mesh do objeto
        MeshFilter meshFilter = square.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }
}
