using UnityEngine;
using System.Collections;

public class enemyship : MonoBehaviour {

	public int health = 2;
	public GameObject explosion;
	public GameObject expOrb;
	public GameObject enemyBullet;
	public int expDrop = 3;
	public AudioClip hitSound;
	public float fireRate = 2.0f;
	
	private float counter = 0.0f;
	
	void  Start (){
		rigidbody.velocity = new Vector3(-2.5f, 0, 0);
	}
	
	void  Update (){
		counter += Time.deltaTime;
		if(transform.position.x < -12){
			Destroy(gameObject);
		}
		
		if (counter <= fireRate) {
			return;
		}
		GameObject custom1 = (GameObject) Instantiate(enemyBullet, transform.position - new Vector3(0.5f,0.1f,0), Quaternion.Euler(-90,0,0));
		GameObject custom2 = (GameObject) Instantiate(enemyBullet, transform.position - new Vector3(0.5f,0.1f,0), Quaternion.Euler(-90,0,0));
		GameObject custom3 = (GameObject) Instantiate(enemyBullet, transform.position - new Vector3(0.5f,0.1f,0), Quaternion.Euler(-90,0,0));
		GameObject custom4 = (GameObject) Instantiate(enemyBullet, transform.position - new Vector3(0.5f,0.1f,0), Quaternion.Euler(-90,0,0));
		custom1.rigidbody.velocity = new Vector3(custom1.rigidbody.velocity.x, custom1.rigidbody.velocity.y, 3);
		custom2.rigidbody.velocity = new Vector3(custom2.rigidbody.velocity.x, custom2.rigidbody.velocity.y, 1);
		custom3.rigidbody.velocity = new Vector3(custom3.rigidbody.velocity.x, custom3.rigidbody.velocity.y, -1);
		custom4.rigidbody.velocity = new Vector3(custom4.rigidbody.velocity.x, custom4.rigidbody.velocity.y, -3);
		counter = 0.0f;
	}
	
	void  hit (){
		health -= 1;
		if (health != 0 && audio.enabled == true) {
			audio.PlayOneShot(hitSound);
		}
		if (health <= 0) {
			onDeath();
		}
	}
	
	void onDeath(){
		while (expDrop >= 0) { 
			Instantiate (expOrb, transform.position, Quaternion.Euler (-90, 0, 0));
			expDrop -= 1;
		}
		Instantiate(explosion,transform.position, Quaternion.Euler(-90, Random.Range(-180, 180), 0));
		Destroy(gameObject);
	}
}