using UnityEngine;

public class Tri : MonoBehaviour
{
    public float sideLength = 1f; // Comprimento do lado do quadrado
    public Material material; // Material para os tri�ngulos

    void Start()
    {
        GenerateSquare();
    }

    void GenerateSquare()
    {
        // Criar os v�rtices dos tri�ngulos
        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(0f, 0f, 0f); // V�rtice inferior esquerdo
        vertices[1] = new Vector3(sideLength, 0f, 0f); // V�rtice inferior direito
        vertices[2] = new Vector3(0f, sideLength, 0f); // V�rtice superior esquerdo
        vertices[3] = new Vector3(sideLength, sideLength, 0f); // V�rtice superior direito

        // Criar os tri�ngulos
        int[] triangles = new int[6];
        triangles[0] = 0; // Primeiro tri�ngulo: v�rtices 0, 1, 2
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2; // Segundo tri�ngulo: v�rtices 2, 1, 3
        triangles[4] = 1;
        triangles[5] = 3;

        // Criar o objeto e adicionar os componentes necess�rios
        GameObject square = new GameObject("Square");
        square.AddComponent<MeshFilter>();
        square.AddComponent<MeshRenderer>();

        // Atribuir o material aos tri�ngulos
        MeshRenderer meshRenderer = square.GetComponent<MeshRenderer>();
        meshRenderer.material = material;

        // Criar o Mesh e atribuir os v�rtices e tri�ngulos
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Atualizar a normal dos tri�ngulos (para c�lculo da ilumina��o)
        mesh.RecalculateNormals();

        // Atribuir o Mesh ao filtro de Mesh do objeto
        MeshFilter meshFilter = square.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }
}
