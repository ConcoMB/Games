using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	
	public float bulletSpeed = 24.0f;

	void  Start (){
		rigidbody.velocity = new Vector2(bulletSpeed, rigidbody.velocity.y);
	}	
	
	void  Update (){
		if(transform.position.x > 12){
			Destroy(gameObject);
		}
	}
	
	void  OnTriggerEnter(Collider other){
		if (other.tag == "enemy"){
			other.BroadcastMessage("hit", SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}