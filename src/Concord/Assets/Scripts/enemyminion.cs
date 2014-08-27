using UnityEngine;
using System.Collections;

public class enemyminion : MonoBehaviour {

	public int health = 2;
	public GameObject explosion;
	public GameObject expOrb;
	public GameObject bullet;
	public float shotSpeed = 1.0f;
	public int expDrop = 3;
	public AudioClip hitSound;

	private GameObject target;
	private float zPosition;
	private float counter = 0.0f;
	
	void Start() {
		rigidbody.velocity = new Vector2(-4, 0);
		rigidbody.angularVelocity = new Vector2(0, Random.Range(-6, 6));
		zPosition = transform.position.z;
		target = GameObject.Find("player");
	}
	
	void Update() {
		counter += Time.deltaTime;
		if (transform.position.x < -12) {
			Destroy(gameObject);
		}
		if (Time.timeScale == 1){
			transform.position = new Vector3(transform.position.x, transform.position.y, 
			                                 zPosition + Mathf.Sin(Time.time * 2) * 2);
		}
		if (counter > shotSpeed && target != null) {
			if (transform.position.x > target.transform.position.x + 6) {
				Instantiate(bullet, transform.position, Quaternion.Euler(-90, 0, 0));
			}
			counter = 0.0f;
		}
	}
	
	void hit(){
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
		Instantiate(explosion, transform.position, Quaternion.Euler(-90, Random.Range(-180,180), 0));
		Destroy(gameObject);
	}
}