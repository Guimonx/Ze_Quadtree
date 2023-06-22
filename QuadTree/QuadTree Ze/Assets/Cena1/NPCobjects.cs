using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCobjects : Objects
{
   
    public override void Objupdate()
    {
        //movimentação
      //  gameObject.SetActive(true);
        gameObject.GetComponent<Renderer>().material.color = Color.green;

    }

	public override void ObjChangeColor()
	{
       // gameObject.SetActive(false);
        gameObject.GetComponent<Renderer>().material.color = Color.red;




    }


}
