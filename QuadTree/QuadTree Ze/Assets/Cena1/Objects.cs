using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{

    void Start()
    {
        



    }

   
    public virtual void Objupdate()
    {
        


    }

    public virtual void ObjChangeColor()
    {
        


    }

    public virtual bool ObjCollision(Objects obj)
	{
        bool Iscolidindo = false;
        float distance;
        distance = Vector3.Distance(transform.position, obj.transform.position);

        if(distance <= 1.5f)
		{
            Iscolidindo = true;

		}




        return Iscolidindo;
    }
}
