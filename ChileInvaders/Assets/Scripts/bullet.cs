using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	
	
	//here is the bullet speed that can be access in the inspector because its a public variable
	public float bulletSpeed = 24.0f;
	
	//we get the bullet moving at the speed set to the bullet in the inspector.
	void  Start (){
		rigidbody.velocity = new Vector2(bulletSpeed, rigidbody.velocity.y);
	}
	
	
	void  Update (){
		//if the bullet goes too far right, we destroy the bullet.
		if(transform.position.x > 12){
			Destroy(gameObject);
		}
	}
	
	//if the bullet hits an object tagged as an enemy, it'll send them a message that they were hit, then destroy itself.
	void  OnTriggerEnter ( Collider other  ){
		if(other.tag == "enemy"){
			other.BroadcastMessage("hit", SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}