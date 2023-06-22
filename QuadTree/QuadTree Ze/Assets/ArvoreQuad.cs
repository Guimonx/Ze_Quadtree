using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArvoreQuad : MonoBehaviour
{
	
	private Material material;
	private int nivel = 0;
	private Vector3 centro;
	//private float pos = 10;
	private int pos = 10;
	private float x, y;
	private Quadrante[] cel;
	private GameObject square;
	private List<GameObject> listQuad = new List<GameObject>();

	public ArvoreQuad(Material material)
	{
		this.material = material;
		//this.xx = xx;
		//this.yy = yy;
		//this.pos = pos;

		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				GerarQuadrante(i * pos,j * pos);
				listQuad.Add(square);
			}
		}

	}
	// -----------------------------------------------------------------------------
	void Start()
    {
        
    }


    // -------------------------------------------------------------------------------
    void Update()
    {
        
    }

	public void Dividir()
	{


		if (nivel <= 1)
		{
			//Destroy(square);

			cel[0] = new Quadrante(material, x, y, pos / 2);
			cel[1] = new Quadrante(material, x, y + pos / 2, pos / 2); //erro
			cel[2] = new Quadrante(material, x + pos / 2, y, pos / 2);
			cel[3] = new Quadrante(material, x + pos / 2, y + pos / 2, pos / 2); //erro

		}


	}

	public void GerarQuadrante(int x,int y)
    {



		Vector3[] vertices = new Vector3[4];
		vertices[0] = new Vector3(x, 0, y); // Vértice inferior esquerdo
		vertices[1] = new Vector3(x + pos, 0, y); // Vértice inferior direito
		vertices[2] = new Vector3(x , 0, y + pos); // Vértice superior esquerdo
		vertices[3] = new Vector3(x + pos , 0, y + pos); // Vértice superior direito
		centro = new Vector3(pos / 2, 0, pos / 2);


		// Criar os triângulos
		int[] triangles = new int[6];
		triangles[0] = 2;
		triangles[1] = 1;
		triangles[2] = 0;
		triangles[3] = 3;
		triangles[4] = 1;
		triangles[5] = 2;


		// Criar o objeto e adicionar os componentes necessários
	    square = new GameObject("Square");
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

		//square.transform.position = new Vector3(x, 0, y);
	}
}
