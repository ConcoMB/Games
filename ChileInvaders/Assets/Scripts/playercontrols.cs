using UnityEngine;
using System.Collections;

public class playercontrols : MonoBehaviour {

	public float shipSpeed = 16.0f;
	public bool twoAxis= true;
	private GameObject mainCamera;
	
	void  Start (){
		mainCamera = GameObject.Find("Main Camera");
	}
	
	void  Update (){
		if(Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("up") || Input.GetKey("down")){
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
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
		}
		
		if(twoAxis == true){
			if(Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("left") || Input.GetKey("right")){
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