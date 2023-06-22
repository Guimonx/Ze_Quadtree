using UnityEngine;
using System.Collections.Generic;

public class Quadtree
{
    private Bounds bounds;
    private float minSize;
    private int maxObjects;
    private int maxLevels;

    private int level;
    private List<GameObject> objects;
    private Quadtree[] children;

    public Quadtree(Bounds bounds, float minSize, int maxObjects, int maxLevels, int level = 0)
    {
        this.bounds = bounds;
        this.minSize = minSize;
        this.maxObjects = maxObjects;
        this.maxLevels = maxLevels;

        this.level = level;
        objects = new List<GameObject>();
        children = new Quadtree[4];
    }

    public void Insert(GameObject obj)
    {
        if (children[0] != null)
        {
            int index = GetChildIndex(obj.transform.position);
            if (index != -1)
            {
                children[index].Insert(obj);
                return;
            }
        }

        objects.Add(obj);

        if (objects.Count > maxObjects && level < maxLevels)
        {
            if (children[0] == null)
            {
                Subdivide();
            }

            int i = 0;
            while (i < objects.Count)
            {
                int index = GetChildIndex(objects[i].transform.position);
                if (index != -1)
                {
                    children[index].Insert(objects[i]);
                    objects.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }
    }

    public List<GameObject> Retrieve(Vector3 position)
    {
        List<GameObject> result = new List<GameObject>();
        result.AddRange(objects);

        if (children[0] != null)
        {
            int index = GetChildIndex(position);
            if (index != -1)
            {
                result.AddRange(children[index].Retrieve(position));
            }
            else
            {
                for (int i = 0; i < children.Length; i++)
                {
                    result.AddRange(children[i].Retrieve(position));
                }
            }
        }

        return result;
    }

    public void Clear()
    {
        objects.Clear();

        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] != null)
            {
                children[i].Clear();
                children[i] = null;
            }
        }
    }

    private void Subdivide()
    {
        Vector3 center = bounds.center;
        float halfSize = bounds.size.x / 4f;

        children[0] = new Quadtree(new Bounds(new Vector3(center.x - halfSize, 0f, center.z - halfSize), Vector3.one * halfSize * 2f), minSize, maxObjects, maxLevels, level + 1);
        children[1] = new Quadtree(new Bounds(new Vector3(center.x - halfSize, 0f, center.z + halfSize), Vector3.one * halfSize * 2f), minSize, maxObjects, maxLevels, level + 1);
        children[2] = new Quadtree(new Bounds(new Vector3(center.x + halfSize, 0f, center.z - halfSize), Vector3.one * halfSize * 2f), minSize, maxObjects, maxLevels, level + 1);
        children[3] = new Quadtree(new Bounds(new Vector3(center.x + halfSize, 0f, center.z + halfSize), Vector3.one * halfSize * 2f), minSize, maxObjects, maxLevels, level + 1);
    }

    private int GetChildIndex(Vector3 position)
    {
        if (position.x < bounds.center.x)
        {
            if (position.z < bounds.center.z)
                return 0;
            else
                return 1;
        }
        else
        {
            if (position.z < bounds.center.z)
                return 2;
            else
                return 3;
        }
    }
}

