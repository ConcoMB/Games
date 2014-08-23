
using UnityEngine;
using System.Collections;

public class asteroid : MonoBehaviour {
	
	
	//here are public variables that can be accessed in the inspector
	public int health = 2;
	public GameObject explosion;
	public GameObject expOrb;
	public int expDrop = 3;
	public AudioClip hitSound;
	
	//we get the asteroid to start at a random speed going left as well as a random rotation.
	void  Start (){
		rigidbody.velocity = new Vector3(Random.Range (-10, -6), 0, 0);
		rigidbody.angularVelocity = new Vector3(0, Random.Range(-6,6), 0);
	}
	
	void  Update (){
		//if the asteroid goes too far left, we destroy it
		if(transform.position.x < -12){
			Destroy(gameObject);
		}
		
		//end of function update
	}
	
	//if a bullet hits, it'll send a message here to say it was hit and we can bring the health down
	void  hit (){
		health -= 1;
		if(health != 0){
			if(audio.enabled == true){
				audio.PlayOneShot(hitSound);
			}
		}
		if(health <= 0){
			onDeath();
		}
	}
	
	//once health is at 0, this function is triggered to release some orbs and release the explosion animation object before its destroyed
	void  onDeath (){
		Instantiate(expOrb,transform.position,Quaternion.Euler(-90,0,0));
		expDrop -= 1;
		if(expDrop <= 0){
			Instantiate(explosion,transform.position,Quaternion.Euler(-90,Random.Range(-180,180),0));
			Destroy(gameObject);
		}
		if(expDrop > 0){
			onDeath();
		}
	}
}