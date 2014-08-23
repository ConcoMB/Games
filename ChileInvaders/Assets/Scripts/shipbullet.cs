using UnityEngine;
using System.Collections;

public class shipbullet : MonoBehaviour {

	private float lifeCounter = 0.0f;
	
	void  Start (){
		rigidbody.velocity = new Vector3(-8, rigidbody.velocity.y, rigidbody.velocity.z);
	}
	
	void  Update (){
		lifeCounter += Time.deltaTime;
		if (transform.position.x < -12) {
			Destroy(gameObject);
		}
		if (lifeCounter > 6) {
			Destroy(gameObject);
		}
	}
}