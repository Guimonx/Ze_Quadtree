using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCobjects : Objects
{
    public float moveSpeed = 5f; 

    private Vector3 targetPosition; 

    public override void Objupdate()
    {
   
        gameObject.GetComponent<Renderer>().material.color = Color.green;

        if (transform.position == targetPosition)
        {
            SetRandomTargetPosition();
        }

      
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }

    public override void ObjChangeColor()
	{
      
        gameObject.GetComponent<Renderer>().material.color = Color.red;


    }
    private void SetRandomTargetPosition()
    {
       
        float targetX = Random.Range(1, 200f);
        float targetZ = Random.Range(1, 200f);
        targetPosition = new Vector3(targetX, transform.position.y, targetZ);
    }



}
