using UnityEngine;
using System.Collections;

public class weaponsystem : MonoBehaviour {

	public GameObject bullet1;
	public AudioClip shotSound;
	public float fireRate = 4.0f;
	public float fireRateLevelScale = 0.5f;
	private float counter = 0.0f;
	private int level = 1;
	
	void  Update (){
		counter += Time.deltaTime;
		if(Input.GetKey("space")) {
			if (counter <= 1 / fireRate){
				return;
			}
			if (level < 3){
				Instantiate(bullet1, transform.position+ new Vector3(0.5f, -0.1f, 0), Quaternion.Euler(-90, 0, 0));
			} else if (level < 5){
				Instantiate(bullet1, transform.position+ new Vector3(0.5f, -0.1f, 0.5f), Quaternion.Euler(-90, 0, 0));
				Instantiate(bullet1, transform.position+ new Vector3(0.5f, -0.1f, -0.5f), Quaternion.Euler(-90, 0, 0));
			} else {
				Instantiate(bullet1, transform.position+ new Vector3(0.5f, -0.1f, 0.25f), Quaternion.Euler(-90, 0, 0));
				Instantiate(bullet1, transform.position+ new Vector3(0.5f, -0.1f, -0.25f), Quaternion.Euler(-90, 0, 0));
				GameObject custom1= (GameObject) Instantiate(bullet1, transform.position + 
				                                             new Vector3(0.5f, -0.1f, 0.5f), Quaternion.Euler(-90,0,0));
				GameObject custom2= (GameObject) Instantiate(bullet1, transform.position +
				                                             new Vector3(0.5f, -0.1f, -0.5f), Quaternion.Euler(-90,0,0));
				custom1.transform.rigidbody.velocity = new Vector3(0, 0, 3);
				custom2.transform.rigidbody.velocity = new Vector3(0, 0, -3);
			}
			audio.PlayOneShot(shotSound);
			counter = 0.0f;
		}
	}
	
	void  levelup (int lvlNumber){
		level = lvlNumber;
		fireRate += fireRateLevelScale;
	}
}