using UnityEngine;
using System.Collections;

public class enemybullet : MonoBehaviour {

	
	//this is the bullet that the orb uses. we make the bullet shoot towards the player by giving it a directional velocity on start. 
	//we don't want it to keep following after this, just a straight line after it spawns.
	
	public float bulletSpeed = 24.0f;
	
	private GameObject target;
	private float lifeCounter = 0.0f;
	
	void  Start (){
		//we find the player and set it as target.
		target = GameObject.Find("player");
		if(target != null){
			//if the target still exists, we go ahead and figure out where it is in reference to the bullet
			Vector2 dir= target.transform.position - transform.position;
			dir = dir.normalized;
			//we add force to the bullet towards the direction (dir) that we found the player to be at.
			rigidbody.AddForce(dir * 350);
		}
	}
	
	void  Update (){
		//we use lifeCounter to check to make sure the bullet doesnt exist for too long
		lifeCounter += Time.deltaTime;
		//if the bullet goes too left, we destroy it.
		if(transform.position.x < -12){
			Destroy(gameObject);
		}
		//if the bullet is "alive" for longer than 6 seconds, we destroy it.
		if(lifeCounter > 6){
			Destroy(gameObject);
		}
	}
}