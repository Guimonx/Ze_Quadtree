using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadrante : MonoBehaviour
{

    public float LarguraQuad = 10f; // Comprimento do lado do quadrado
   // public Material material; // Material para os triângulos
    private Material material;
    private int nivel = 0;
    private Vector3 centro;
    //private float pos = 10;
    private float pos;
    private float x,y;
    private Quadrante[] cel;
    private GameObject square;
    

    public Quadrante(Material material, float x, float y, float pos)
	{
        this.material = material;
        this.x = x;
        this.y = y;
        this.pos = pos;
        cel = new Quadrante[4];

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(0, 0, 0); // Vértice inferior esquerdo
        vertices[1] = new Vector3(pos, 0, 0); // Vértice inferior direito
        vertices[2] = new Vector3(0, 0, pos); // Vértice superior esquerdo
        vertices[3] = new Vector3(pos, 0, pos); // Vértice superior direito
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

        square.transform.position = new Vector3(x, 0, y);
    }

    void Start()
    {
      
    }

    public void Dividir()
	{
      

        if (nivel == 1)
        {
            Destroy(square);
            
            cel[0] = new Quadrante(material, x, y, pos / 2);
            cel[1] = new Quadrante(material, x, y + pos / 2, pos / 2); //erro

            cel[2] = new Quadrante(material, x + pos / 2, y, pos / 2);
            cel[3] = new Quadrante(material, x + pos / 2, y + pos / 2, pos / 2); //erro
        }


    }


	public void GerarQuadrante()
	{

		// Criar os vértices dos triângulos
		//Vector3[] vertices = new Vector3[4];
		//vertices[0] = new Vector3(0, 0, 0); // Vértice inferior esquerdo
		//vertices[1] = new Vector3(LarguraQuad, 0, 0); // Vértice inferior direito
		//vertices[2] = new Vector3(0, 0, LarguraQuad); // Vértice superior esquerdo
		//vertices[3] = new Vector3(LarguraQuad, 0, LarguraQuad); // Vértice superior direito



		

		//Vector3[] vertices = new Vector3[4];
		//vertices[0] = new Vector3(0, 0, 0); // Vértice inferior esquerdo
		//vertices[1] = new Vector3(pos, 0, 0); // Vértice inferior direito
		//vertices[2] = new Vector3(0, 0, pos); // Vértice superior esquerdo
		//vertices[3] = new Vector3(pos, 0, pos); // Vértice superior direito
  //      centro = new Vector3(pos / 2, 0, pos / 2);


  //      // Criar os triângulos
  //      int[] triangles = new int[6];
  //      triangles[0] = 2; 
  //      triangles[1] = 1;
  //      triangles[2] = 0;
  //      triangles[3] = 3; 
  //      triangles[4] = 1;
  //      triangles[5] = 2;


  //      // Criar o objeto e adicionar os componentes necessários
  //      GameObject square = new GameObject("Square");
  //      square.AddComponent<MeshFilter>();
  //      square.AddComponent<MeshRenderer>();

  //      // Atribuir o material aos triângulos
        
        
  //      MeshRenderer meshRenderer = square.GetComponent<MeshRenderer>();
  //      meshRenderer.material = material;
        

  //      // Criar o Mesh e atribuir os vértices e triângulos
  //      Mesh mesh = new Mesh();
  //      mesh.vertices = vertices;
  //      mesh.triangles = triangles;

  //      // Atualizar a normal dos triângulos (para cálculo da iluminação)
  //      mesh.RecalculateNormals();

  //      // Atribuir o Mesh ao filtro de Mesh do objeto
  //      MeshFilter meshFilter = square.GetComponent<MeshFilter>();
  //      meshFilter.mesh = mesh;

  //      square.transform.position = new Vector3(x,0,y);
    }

}



