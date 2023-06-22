using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	// Start is called before the first frame update
	/*-precisar inst�nciar os setores compostos por 2 tri�ngulos
    -inst�nciar os objetos distribu�dos aleatoriamente entre os limites dos setores
    -inst�nciar o jogador
    -fazer a subdivis�o dos setores em setores filhos baseado na dist�ncia do jogador com o centro do setor / ter um limitador de subdivis�o para evitar problema
    -fazer quadrante que se parte em 4 quadrantes menores utilizando valores do maior at� um limite, assim automaticamente ele vai se repartindo baseado no jogador
    -sempre que player se aproximar od centro qudarante if level <=3 -Dividir()

	-inserir na lista interna e retornar par o tratamento!?
	-chamar o m�todo da quadtree no manager e a pr�pria quadtree identificar qual/quais objetos est�o pr�ximos de quais quadrantes
	-m�todo de update da quadtree!? sempre comparar a posi��o do jogadoro com o centro de cada elemento da quadtree

	Inst�nciar os objetos e inserir numa lista

	Quadtree deve se dividir baseado no n�mero de elementos nela
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
