using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STATICobjects : Objects
{
    public override void Objupdate()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
      //  gameObject.SetActive(true);

    }

    public override void ObjChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
       // gameObject.SetActive(false);


    }


}
