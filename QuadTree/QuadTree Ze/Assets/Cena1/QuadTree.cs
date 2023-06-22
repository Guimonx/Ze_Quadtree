using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadTree
{
	//lista interna e lista externa
	//separar o root dos filhos!?

	private Material material;
	private int nivel = 0;
	private Vector3 centro;
	private float size;
	private float posx, posy;
	private GameObject player;
	private QuadTree[] cel;
	public GameObject square;
	private List<QuadTree> quadList = new List<QuadTree>();
	private List<Objects> ObjList = new List<Objects>();
	private int max = 30;
	private bool Isdivided = false;
	private QuadTree quadpai;

	public QuadTree(Material material, float posx, float posy, float size, int nivel, QuadTree quadpai)
	{
		this.quadpai = quadpai;
		quadList.Add(this);
		this.material = material;
		this.posx = posx;
		this.posy = posy;
		this.size = size;
		this.nivel = nivel;
		cel = new QuadTree[4];
		// UpdateQuad();
		// Quad();

	}

	public Vector3 returncentro()
	{
		return centro;
	}


	public void UpdateQuad()
	{

		if (IsDivided() == false)
		{
			for (int i = 0; i < ObjList.Count; i++)
			{
				ObjList[i].Objupdate();


				for (int j = 0; j < ObjList.Count; j++)
				{
					if (j == i)
					{
						continue;
					}
					if (ObjList[j].ObjCollision(ObjList[i]))
					{
						ObjList[i].ObjChangeColor();

					}
				}
			}
			if (quadpai != null)
			{

				for (int i = 0; i < ObjList.Count; i++)
				{
					int index = IsInside(ObjList[i].transform.position);

					if (index == -1)
					{
						if (ObjList[i].name.Length > 15)
						{
							ObjList[i].name = "";
						}
						ObjList[i].name += nivel + "s. ";
						quadpai.Add(ObjList[i]);
						ObjList.RemoveAt(i);

						if(ObjList.Count == 0)
						{
							if(quadpai != null)
							{
								quadpai.Checarfilho();
							}
						}
						return;
					}

				}
			}
		}
		else
		{
			for (int i = 0; i < cel.Length; i++)
			{
				cel[i].UpdateQuad();
			}

		}

	}

	private void Checarfilho()
	{

		for (int i = 0; i < cel.Length; i++)
		{
			
			if(cel[i].ObjList.Count > 0)
			{
				return;
			}
		}

		Isdivided = false;
	}
	private bool IsDivided()
	{

		return Isdivided;
	}

	public void Add(Objects obj)
	{

		if (IsDivided() == false)
		{
			ObjList.Add(obj);

			obj.name += nivel + " a.";

			if (ObjList.Count > 8 && nivel < max)
			{

				Dividir();

				for (int i = 0; i < ObjList.Count; i++)
				{
					int index = IsInside(ObjList[i].transform.position);
					if (index != -1)
					{
						cel[index].Add(ObjList[i]);

					}
					else
					{
						if (quadpai != null)
						{
							quadpai.Add(ObjList[i]);

						}
						else
						{
							ObjList[i].name += nivel + " erro";
						}
					}

				}

				Clear();
			}
		}
		else
		{
			int index = IsInside(obj.transform.position);
			Debug.Log(" index " + index, obj.gameObject);
			if (index != -1)
			{
				cel[index].Add(obj);
				return;
			}
			else
			{
				if (quadpai != null)
				{
					quadpai.Add(obj);

					obj.name += nivel + " v.";
					return;
				}
				else
				{
					obj.name += nivel + " erro";
				}

			}


		}
	}

	private int IsInside(Vector3 position) //novo!!!
	{

		if (position.x >= posx && position.x <= posx + (size / 2))
		{
			if (position.z >= posy && position.z <= posy + (size / 2))
			{
				return 0;
			}
			else if (position.z >= posy + (size / 2) && position.z <= posy + size)
			{
				return 1;
			}

		}

		else if(position.x >= posx + (size / 2) && position.x <= posx + size)
		{
			
			if (position.z >= posy && position.z <= posy + (size / 2))
			{
				return 2;
			}
			else if (position.z >= posy + (size / 2) && position.z <= posy + size)
			{
				return 3;
			}
		}

		return -1;
	}

	public void Dividir()
	{
		int n = nivel / 10;
		n *= 10;
		cel[0] = new QuadTree(material, posx, posy, size / 2, n + 10, this);
		cel[1] = new QuadTree(material, posx, posy + size / 2, size / 2, n + 11, this); //erro

		cel[2] = new QuadTree(material, posx + size / 2, posy, size / 2, n + 12, this);
		cel[3] = new QuadTree(material, posx + size / 2, posy + size / 2, size / 2, n + 13, this); //erro
		Isdivided = true; //novo!!!
		nivel++;


	}



	public void Clear() //novo!!!
	{
		ObjList.Clear();

		//if (cel[0] != null)
		//{
		//    for (int i = 0; i <= 3; i++)
		//    {
		//        if (cel[i].IsDivided() == true)
		//        {
		//            cel[i].Clear();
		//            cel[i].Isdivided = false;

		//        }
		//    }
		//}

	}


	public void Quad()
	{
		Vector3[] vertices = new Vector3[4];
		vertices[0] = new Vector3(posx, 0, posy); // Vértice inferior esquerdo
		vertices[1] = new Vector3(posx + size, 0, posy); // Vértice inferior direito
		vertices[2] = new Vector3(posx, 0, posy + size); // Vértice superior esquerdo
		vertices[3] = new Vector3(posx + size, 0, posy + size); // Vértice superior direito

		centro = new Vector3(size / 2, 0, size / 2);


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

		// square.transform.position = new Vector3(posx, 0, posy);
		max++;


	}

	public void Drawgizmos()
	{
		if (Isdivided == false)
		{
			Gizmos.color = new Color(nivel / max, 0, 1 - (nivel / max));
			Vector3 start = new Vector3(posx, 0, posy);
			Vector3 end = new Vector3(posx + size, 0, posy);
			Gizmos.DrawLine(start, end);

			start = end;//new Vector3(posx, 0, posy);
			end = new Vector3(posx + size, 0, posy + size);
			Gizmos.DrawLine(start, end);

			start = end;//new Vector3(posx, 0, posy);
			end = new Vector3(posx, 0, posy + size);
			Gizmos.DrawLine(start, end);

			start = end;//new Vector3(posx, 0, posy);
			end = new Vector3(posx, 0, posy);
			Gizmos.DrawLine(start, end);


		}
		else
		{
			for (int i = 0; i < cel.Length; i++)
			{
				cel[i].Drawgizmos();
			}
		}


	}




	//public List<Objects> PegarLista(Vector3 position)
	//{
	//    List<Objects> result = new List<Objects>();
	//    result.AddRange(ObjList);

	//    if (IsDivided() == true)
	//    {
	//        int index = IsInside(position);
	//        if (index != -1)
	//        {
	//            result.AddRange(cel[index].PegarLista(position));
	//        }
	//        else
	//        {
	//            for (int i = 0; i < cel.Length; i++)
	//            {
	//                result.AddRange(cel[i].PegarLista(position));
	//            }
	//        }
	//    }

	//    return result;
	//}

}



