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
		 

		quadTree = new QuadTree(material,0,0,200,0, null); //novo!!!
		go = Instantiate(Player, new Vector3(1, 0, 1), Quaternion.identity);
		go.name = "player";	
		quadTree.Add(go);

		
		Vector3 start = new Vector3(1, 0, 1);


		for (int i = 0; i < objcount; i++)
		{
			start.x = (i % 10) * 7;
			start.z = (i / 5) * 10;

			go = Instantiate(NPCobj, new Vector3(Random.Range(1, 200), 0, Random.Range(1, 200)), Quaternion.identity);
			go.name = "NPCobj";
			quadTree.Add(go);

			

			start += new Vector3(3, 0, 3);


			//go = Instantiate(STATICobj, start, Quaternion.identity);
			go = Instantiate(STATICobj, new Vector3(Random.Range(1,200), 0, Random.Range(1, 200)), Quaternion.identity);
			go.name = "NPCobj";
			quadTree.Add(go);

		}

	



	}


	void Update()
	{


		quadTree.UpdateQuad(); //novo!!!

	


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
