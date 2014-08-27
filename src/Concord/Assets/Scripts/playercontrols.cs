using UnityEngine;
using System.Collections;

public class playercontrols : MonoBehaviour {

	public float shipSpeed = 16.0f;
	public int veloticyFactor = 48;
	private GameObject mainCamera;
	
	void  Start (){
		mainCamera = GameObject.Find("Main Camera");
	}
	
	void  Update (){
		if(isUpPressed() || isDownPressed()){
			if(isDownPressed()){
				if(rigidbody.velocity.z > 0){
					rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
				}
				if(rigidbody.velocity.z > -shipSpeed){
					rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 
					                                 rigidbody.velocity.z - veloticyFactor * Time.deltaTime);
				}
			}
			if(isUpPressed()){
				if(rigidbody.velocity.z < 0){
					rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
				}
				if(rigidbody.velocity.z < shipSpeed){
					rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y,
					                                 rigidbody.velocity.z + veloticyFactor * Time.deltaTime);
				}
			}
		} else {
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 0);
		}
		
		if(isLeftPressed() || isRightPressed()){
			if(isLeftPressed()){
				if(rigidbody.velocity.x > 0){
					rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
				}
				if(rigidbody.velocity.x > -shipSpeed){
					rigidbody.velocity = new Vector3(rigidbody.velocity.x - veloticyFactor * Time.deltaTime, 
					                                 rigidbody.velocity.y, rigidbody.velocity.z);
				}
			}
			if(isRightPressed()){
				if(rigidbody.velocity.x < 0){
					rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
				}
				if(rigidbody.velocity.x < shipSpeed){
					rigidbody.velocity = new Vector3(rigidbody.velocity.x + veloticyFactor * Time.deltaTime, 
					                                 rigidbody.velocity.y, rigidbody.velocity.z);
				}
			}
		} else {
			rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, rigidbody.velocity.z);
		}
	}

	private bool isUpPressed() {
		return Input.GetKey("w")|| Input.GetKey("up");
	}
	
	private bool isDownPressed() {
		return Input.GetKey("s")|| Input.GetKey("down");
	}
	
	private bool isLeftPressed() {
		return Input.GetKey("a")|| Input.GetKey("left");
	}

	private bool isRightPressed() {
		return Input.GetKey("d")|| Input.GetKey("right");
	}
}