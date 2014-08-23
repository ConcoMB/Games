
using UnityEngine;
using System.Collections;

public class asteroid : MonoBehaviour {
	
	public int health = 2;
	public GameObject explosion;
	public GameObject expOrb;
	public int expDrop = 3;
	public AudioClip hitSound;
	
	void  Start (){
		rigidbody.velocity = new Vector3(Random.Range (-10, -6), 0, 0);
		rigidbody.angularVelocity = new Vector3(0, Random.Range(-6, 6), 0);
	}
	
	void  Update (){
		if (transform.position.x < -12) {
			Destroy(gameObject);
		}
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
		Instantiate(explosion,transform.position, Quaternion.Euler(-90,Random.Range(-180,180), 0));
		Destroy(gameObject);
	}
}