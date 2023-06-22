using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    public GameObject staticElementPrefab;
    public GameObject dynamicElementPrefab;
    public GameObject playerPrefab;

    public int staticElementCount = 50;
    public int dynamicElementCount = 50;

    public float quadtreeMinSize = 5f;
    public int quadtreeMaxObjects = 10;
    public int quadtreeMaxLevels = 5;

    private Quadtree quadtree;
    private GameObject player;

    private void Start()
    {
        quadtree = new Quadtree(new Bounds(Vector3.zero, Vector3.one * 100f), quadtreeMinSize, quadtreeMaxObjects, quadtreeMaxLevels);

        for (int i = 0; i < staticElementCount; i++)
        {
            Vector3 position = GenerateRandomPosition();
            Instantiate(staticElementPrefab, position, Quaternion.identity);
        }

        for (int i = 0; i < dynamicElementCount; i++)
        {
            Vector3 position = GenerateRandomPosition();
            Instantiate(dynamicElementPrefab, position, Quaternion.identity);
        }

        Vector3 playerPosition = GenerateRandomPosition();
        player = Instantiate(playerPrefab, playerPosition, Quaternion.identity);
    }

    private void Update()
    {
        quadtree.Clear();

        //Element[] elements = FindObjectsOfType<Element>();
        //foreach (Element element in elements)
        //{
        //    quadtree.Insert(element.gameObject);
        //}

        //List<GameObject> nearbyElements = quadtree.Retrieve(player.transform.position);
        //foreach (GameObject element in nearbyElements)
        //{
        //    if (element != player)
        //    {
        //        if (element.CompareTag("StaticElement") || element.CompareTag("DynamicElement"))
        //        {
        //            element.GetComponent<Element>().OnCollision();
        //        }
        //    }
        //}
    }

    private Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(-40f, 40f);
        float z = Random.Range(-40f, 40f);
        return new Vector3(x, 0f, z);
    }
}