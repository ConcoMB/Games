using UnityEngine;
using System.Collections;

public class boss : MonoBehaviour {

	public int maxhealth = 200;
	public GameObject explosion;
	public GameObject enemyBullet;
	public GameObject youWonText;
	public AudioClip hitSound;
	public float fireRate = 2.0f;
	public float xPositionLimit;

	private int health;
	private float counter = 0.0f;
	private float maxUpAndDown = 4f;
	private float speed = 100;
	private float angle = 0;
	private float toDegrees = Mathf.PI / 180;
	private float startHeight;

	void  Start (){
		health = maxhealth;
		rigidbody.velocity = new Vector3(-4f, 0, 0);
	}
	
	void  Update () {
		if (rigidbody.position.x <= xPositionLimit) {
			angle += speed * Time.deltaTime;
			if (angle > 270) angle -= 360;
			transform.position = new Vector3(xPositionLimit, 0, startHeight + maxUpAndDown * (Mathf.Sin(angle * toDegrees)) / 2);
		}
		counter += Time.deltaTime;
		if (counter <= fireRate) {
			return;
		}
		GameObject custom1 = (GameObject) Instantiate(enemyBullet, transform.position - new Vector3(0.5f, 0.1f, 0), 
		                                              Quaternion.Euler(-90, 0, 0));
		GameObject custom2 = (GameObject) Instantiate(enemyBullet, transform.position - new Vector3(0.5f, 0.1f, 0), 
		                                              Quaternion.Euler(-90, 0, 0));
		GameObject custom3 = (GameObject) Instantiate(enemyBullet, transform.position - new Vector3(0.5f, 0.1f, 0), 
		                                              Quaternion.Euler(-90, 0, 0));
		GameObject custom4 = (GameObject) Instantiate(enemyBullet, transform.position - new Vector3(0.5f, 0.1f, 0), 
		                                              Quaternion.Euler(-90, 0, 0));
		custom1.rigidbody.velocity = new Vector3(custom1.rigidbody.velocity.x, custom1.rigidbody.velocity.y, 3);
		custom2.rigidbody.velocity = new Vector3(custom2.rigidbody.velocity.x, custom2.rigidbody.velocity.y, 1);
		custom3.rigidbody.velocity = new Vector3(custom3.rigidbody.velocity.x, custom3.rigidbody.velocity.y, -1);
		custom4.rigidbody.velocity = new Vector3(custom4.rigidbody.velocity.x, custom4.rigidbody.velocity.y, -3);
		counter = 0.0f;
	}
	
	void  hit (){
		health -= 1;
		if (health == maxhealth / 2) {
			Texture texture = (Texture) Resources.Load("finalboss");
			renderer.material.mainTexture = texture;
			fireRate *= 0.5f;
		}
		if (health != 0 && audio.enabled == true){
			audio.PlayOneShot(hitSound);
		}
		if(health <= 0){
			onDeath();
		}
	}
	
	void  onDeath () {
		Instantiate(explosion, transform.position, Quaternion.Euler(-90, Random.Range(-180, 180), 0));
		Instantiate(explosion, transform.position + new Vector3(-1, 0, -1), Quaternion.Euler(-90, Random.Range(-180, 180), 0));
		Instantiate(explosion, transform.position + new Vector3(1, 0, 1), Quaternion.Euler(-90, Random.Range(-180, 180), 0));
		Instantiate(explosion, transform.position + new Vector3(-1, 0, 1), Quaternion.Euler(-90, Random.Range(-180, 180), 0));
		Instantiate(explosion, transform.position + new Vector3(1, 0, -1), Quaternion.Euler(-90, Random.Range(-180, 180), 0));
		Destroy(gameObject);
		GameObject.Find("enemyspawner").SendMessage("win", SendMessageOptions.DontRequireReceiver);
	}
}