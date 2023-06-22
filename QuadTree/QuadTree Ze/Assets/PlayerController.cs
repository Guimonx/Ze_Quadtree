using UnityEngine;

public class PlayerController : Objects
{
    public float speed = 5f;

    public virtual void PlayerUpdate()
	{
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed;
        transform.position += movement * Time.deltaTime;

    }

	public override void Objupdate()
	{
        PlayerUpdate();


        
      
	}



	public bool PlayerCollision(PlayerController PC)
	{
        bool Iscolidindo = false;



        return Iscolidindo;

	}
   
}