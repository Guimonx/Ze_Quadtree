using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	// Start is called before the first frame update
	/*-precisar instânciar os setores compostos por 2 triângulos
    -instânciar os objetos distribuídos aleatoriamente entre os limites dos setores
    -instânciar o jogador
    -fazer a subdivisão dos setores em setores filhos baseado na distância do jogador com o centro do setor / ter um limitador de subdivisão para evitar problema
    -fazer quadrante que se parte em 4 quadrantes menores utilizando valores do maior até um limite, assim automaticamente ele vai se repartindo baseado no jogador
    -sempre que player se aproximar od centro qudarante if level <=3 -Dividir()

	-inserir na lista interna e retornar par o tratamento!?
	-chamar o método da quadtree no manager e a própria quadtree identificar qual/quais objetos estão próximos de quais quadrantes
	-método de update da quadtree!? sempre comparar a posição do jogadoro com o centro de cada elemento da quadtree

	Instânciar os objetos e inserir numa lista

	Quadtree deve se dividir baseado no número de elementos nela
    */


	QuadTree quadTree;
	
	private List<QuadTree> quadList = new List<QuadTree>();

	//public GameObject player;
	public Material material;

	private List<Objects> ListObj = new List<Objects>(); 
	
	public PlayerController Player;
	public NPCobjects NPCobj;
	public STATICobjects STATICobj;
	public int objcount = 5;




	void Start()
	{
		Objects go;
		 

		quadTree = new QuadTree(material,0,0,100,0, null); //novo!!!
		go = Instantiate(Player, new Vector3(1, 0, 1), Quaternion.identity);
		go.name = "player";	
		quadTree.Add(go);

		
		Vector3 start = new Vector3(1, 0, 1);


		for (int i = 0; i < objcount; i++)
		{
			start.x = (i % 10) * 7;
			start.z = (i / 5) * 10;

			go = Instantiate(NPCobj, start, Quaternion.identity);
			go.name = "NPCobj";
			quadTree.Add(go);

			

			start += new Vector3(3, 0, 3);

			
			go = Instantiate(STATICobj, start, Quaternion.identity);
			go.name = "NPCobj";
			quadTree.Add(go);

		}

		

		//for (int i = 0; i < 50; i++)
		//{
		//	start.x = ((i + 50) % 10) * 10;
		//	start.z = ((i + 50) / 10) * 10;

		//	//ListObj.Add(Instantiate(NPCobj, start, Quaternion.identity));

		//	//start += new Vector3(3, 0, 3);

		//	ListObj.Add(Instantiate(STATICobj, start, Quaternion.identity));


		//}






		//quadt = new QuadTree(material, 0 * 10, 0 * 10, 10);
		//quadList.Add(quadt);

		//for (int i = 0; i < 5; i++)
		//{
		//	for (int y = 0; y < 5; y++)
		//	{
		//		quadt = new QuadTree(material, i * 10, y * 10, 10);
		//		quadList.Add(quadt);
		//	}
		//}

		//foreach (QuadTree q in quadList)
		//{
		//	//q.Dividir();
		//}






	}


	void Update()
	{


		quadTree.UpdateQuad(); //novo!!!

		

		//foreach (Objects obj in ListObj)
		//{
		//	quadTree.Add(obj);
		//}







		//quadt.UpdateQuad();

		//foreach (QuadTree q in quadList)
		//{
		//	//para cada objeto dentro da lista/ chamar o update 
		//	//para cada objeto chamar a colisão
		//	float distance;
		//	distance = Vector3.Distance(q.returncentro(), player.transform.position);
		//	if (distance <= 3)
		//	{
		//		q.Dividir();
		//	}

		//}




	}

	private void OnDrawGizmos()
	{
		if(quadTree == null)
		{
			return;
		}
		quadTree.Drawgizmos();
	}
}
