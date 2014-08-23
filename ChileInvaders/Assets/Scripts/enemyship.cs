using UnityEngine;
using System.Collections;

public class enemyship : MonoBehaviour {
	
	
	// here are public variables for the enemy ship that can be accessed in the inspector
	public int health = 2;
	public GameObject explosion;
	public GameObject expOrb;
	public GameObject enemyBullet;
	public int expDrop = 3;
	public AudioClip hitSound;
	public float fireRate = 2.0f;
	
	//heres the private variable counter to keep track of time for fire rate.
	private float counter = 0.0f;
	
	//we get the ship moving left once it is spawned.
	void  Start (){
		rigidbody.velocity = new Vector3(-2.5f, 0, 0);
	}
	
	void  Update (){
		//here we make counter count based on time for the fire rate
		counter += Time.deltaTime;
		
		//if the ship goes too far left, we destroy it.
		if(transform.position.x < -12){
			Destroy(gameObject);
		}
		
		//here we shoot 4 bullets if the counter counts higher than the fire rate.
		if(counter > fireRate){
			GameObject custom1 = (GameObject) Instantiate(enemyBullet, transform.position - new Vector3(0.5f,0.1f,0), Quaternion.Euler(-90,0,0));
			GameObject custom2 = (GameObject) Instantiate(enemyBullet, transform.position - new Vector3(0.5f,0.1f,0), Quaternion.Euler(-90,0,0));
			GameObject custom3 = (GameObject) Instantiate(enemyBullet, transform.position- new Vector3(0.5f,0.1f,0), Quaternion.Euler(-90,0,0));
			GameObject custom4 = (GameObject) Instantiate(enemyBullet, transform.position- new Vector3(0.5f,0.1f,0), Quaternion.Euler(-90,0,0));
			//to make the bullets spread, we add extra z velocity to each one to they all move on their own path.
			custom1.rigidbody.velocity = new Vector3(custom1.rigidbody.velocity.x, custom1.rigidbody.velocity.y, 3);
			custom2.rigidbody.velocity = new Vector3(custom2.rigidbody.velocity.x, custom2.rigidbody.velocity.y, 1);
			custom3.rigidbody.velocity = new Vector3(custom3.rigidbody.velocity.x, custom3.rigidbody.velocity.y, -1);
			custom4.rigidbody.velocity = new Vector3(custom4.rigidbody.velocity.x, custom4.rigidbody.velocity.y -3);
			counter = 0.0f;
		}
		
		//end of function update
	}
	
	//if a bullet hits the ship, the bullets sends us the hit message to trigger this function to bring down the ships health
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
	
	//if health is 0, then this function is triggered to spawn some orbs, spawn the explosion animation object, and destroy itself
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