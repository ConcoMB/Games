using UnityEngine;
using System.Collections;

public class experience : MonoBehaviour {

	//private variable that will be set to the player so we can make the orbs move towards it
	private GameObject target;
	
	void  Start (){
		target = GameObject.Find("player");
		//the orbs go a random direction as first so they're not all clustered together when they're spawned by enemies.
		rigidbody.velocity = new Vector3(Random.Range(-4,4),0,Random.Range(-4,4));
	}
	
	void  Update (){
		//this finds the player (target) and makes it fly towards the player until it hits the player
		if(target != null){
			Vector2 dir= target.transform.position - transform.position;
			dir = dir.normalized;
			rigidbody.AddForce(dir * 1000 * Time.deltaTime);
		}
	}
}