using UnityEngine;
using System.Collections;

public class playercontrols : MonoBehaviour {
	
	
	//open variables that are accessed through inspector including ship speed and if the ship can be controls on 2-axis (left,right,up,down vs. up,down)
	public float shipSpeed = 16.0f;
	public bool twoAxis= true;
	
	//we access the maincamera during start so we can use it for the mobile controls
	private GameObject mainCamera;
	
	void  Start (){
		//here we find the camera to set it up as the mainCamera variable
		mainCamera = GameObject.Find("Main Camera");
	}
	
	void  Update (){
		//This is for desktop builds
		//This checks to see if the player is pressing W, S, Up, or Down. This is connected to the else{} statement below
		if(Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("up") || Input.GetKey("down")){
			//If the player presses A, add velocity to move left.
			if(Input.GetKey("s") || Input.GetKey("down")){
				if(rigidbody.velocity.z > 0){
					rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
				}
				if(rigidbody.velocity.z > -shipSpeed){
					rigidbody.velocity = new Vector3(
						rigidbody.velocity.x,
						rigidbody.velocity.y,
						rigidbody.velocity.z - 48*Time.deltaTime
					);
				}
			}
			//if the player pressed D, add velocity to move right.
			if(Input.GetKey("w")|| Input.GetKey("up")){
				if(rigidbody.velocity.z < 0){
					rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
				}
				if(rigidbody.velocity.z < shipSpeed){
					rigidbody.velocity = new Vector3(
						rigidbody.velocity.x,
						rigidbody.velocity.y,
						rigidbody.velocity.z + 48*Time.deltaTime
					);
				}
			}
		}else{
			//use else to do the opposite of an if() statement. this stops the player if lets go of A or D
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
		}
		
		if(twoAxis == true){
			if(Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("left") || Input.GetKey("right")){
				//If the player presses A, add velocity to move left.
				if(Input.GetKey("a") || Input.GetKey("left")){
					if(rigidbody.velocity.x > 0){
						rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
					}
					if(rigidbody.velocity.x > -shipSpeed){
						rigidbody.velocity = new Vector3(
							rigidbody.velocity.x - 48*Time.deltaTime,
						    rigidbody.velocity.y,
							rigidbody.velocity.z
						);
					}
				}
				//if the player pressed D, add velocity to move right.
				if(Input.GetKey("d")|| Input.GetKey("right")){
					if(rigidbody.velocity.x < 0){
						rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
					}
					if(rigidbody.velocity.x < shipSpeed){
						rigidbody.velocity = new Vector3(
							rigidbody.velocity.x + 48*Time.deltaTime,
							rigidbody.velocity.y,
							rigidbody.velocity.z
						);
					}
				}
			}else{
				rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
			}
		}
	}
}