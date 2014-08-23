using UnityEngine;
using System.Collections;

public class weaponsystem : MonoBehaviour {
	
	
	//here are public variables that are accessed in the inspector like the bullet we shoot, the sound when we shoot it, and how fast it shoots.
	public GameObject bullet1;
	public AudioClip shotSound;
	public float fireRate = 4.0f;
	
	//here are private variables that will change on their own through this script. counter is to limit how fast the bullets shoot so we base that on time.
	private float counter = 0.0f;
	private int level = 1;
	
	void  Update (){
		//here we keep track of time that is applied to the counter so we can limit the fire rate.
		counter += Time.deltaTime;
		
		#if UNITY_WEBPLAYER
		//keyboard controls for web versions that will allow the bullet to shoot
		if(Input.GetKey("space")){
			if(counter > 1/fireRate){
				//we decide after our script allows a bullet to be fired, what variation should be shot, more can be added for any level
				if(level == 1){
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0), Quaternion.Euler(-90,0,0));
				}
				if(level == 2){
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0.5f), Quaternion.Euler(-90,0,0));
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,-0.5f), Quaternion.Euler(-90,0,0));
				}
				if(level >= 3){
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0.25f), Quaternion.Euler(-90,0,0));
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,-0.25f), Quaternion.Euler(-90,0,0));
					FIXME_VAR_TYPE custom1= Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0.5f), Quaternion.Euler(-90,0,0));
					FIXME_VAR_TYPE custom2= Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,-0.5f), Quaternion.Euler(-90,0,0));
					custom1.transform.rigidbody.velocity.z = 3;
					custom2.transform.rigidbody.velocity.z = -3;
				}
				//play the bullet sound
				audio.PlayOneShot(shotSound);
				//we want to reset the counter so that our fire rate always applies
				counter = 0.0f;
			}
		}
		#endif
		
		#if UNITY_STANDALONE
		//keyboard controls for desktop versions that will allow the bullet to shoot
		if(Input.GetKey("space")){
			if(counter > 1/fireRate){
				//we decide after our script allows a bullet to be fired, what variation should be shot, more can be added for any level
				if(level == 1){
					Instantiate(bullet1, transform.position+ new Vector3(0.5f,-0.1f,0), Quaternion.Euler(-90,0,0));
				}
				if(level == 2){
					Instantiate(bullet1, transform.position+ new Vector3(0.5f,-0.1f,0.5f), Quaternion.Euler(-90,0,0));
					Instantiate(bullet1, transform.position+ new Vector3(0.5f,-0.1f,-0.5f), Quaternion.Euler(-90,0,0));
				}
				if(level >= 3){
					Instantiate(bullet1, transform.position+ new Vector3(0.5f,-0.1f,0.25f), Quaternion.Euler(-90,0,0));
					Instantiate(bullet1, transform.position+ new Vector3(0.5f,-0.1f,-0.25f), Quaternion.Euler(-90,0,0));
					GameObject custom1= (GameObject) Instantiate(bullet1, transform.position+ new Vector3(0.5f,-0.1f,0.5f), Quaternion.Euler(-90,0,0));
					GameObject custom2= (GameObject) Instantiate(bullet1, transform.position+ new Vector3(0.5f,-0.1f,-0.5f), Quaternion.Euler(-90,0,0));
					custom1.transform.rigidbody.velocity = new Vector3(0, 0, 3);
					custom2.transform.rigidbody.velocity = new Vector3(0, 0, -3);
				}
				//play the bullet sound
				audio.PlayOneShot(shotSound);
				//we want to reset the counter so that our fire rate always applies
				counter = 0.0f;
			}
		}
		#endif
		
		#if UNITY_ANDROID
		//mobile controls for android that will allow bullet to shoot
		if(Input.touchCount > 0){
			if(counter > 1/fireRate){
				//we decide after our script allows a bullet to be fired, what variation should be shot, more can be added for any level
				if(level == 1){
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0), Quaternion.Euler(-90,0,0));
				}
				if(level == 2){
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0.5f), Quaternion.Euler(-90,0,0));
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,-0.5f), Quaternion.Euler(-90,0,0));
				}
				if(level >= 3){
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0.25f), Quaternion.Euler(-90,0,0));
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,-0.25f), Quaternion.Euler(-90,0,0));
					FIXME_VAR_TYPE custom1= Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0.5f), Quaternion.Euler(-90,0,0));
					FIXME_VAR_TYPE custom2= Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,-0.5f), Quaternion.Euler(-90,0,0));
					custom1.transform.rigidbody.velocity.z = 3;
					custom2.transform.rigidbody.velocity.z = -3;
				}
				//play the bullet sound
				audio.PlayOneShot(shotSound);
				//we want to reset the counter so that our fire rate always applies
				counter = 0.0f;
			}
		}
		#endif
		
		#if UNITY_IPHONE
		//mobile controls for ios that will allow bullet to shoot
		if(Input.touchCount > 0){
			if(counter > 1/fireRate){
				//we decide after our script allows a bullet to be fired, what variation should be shot, more can be added for any level
				if(level == 1){
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0), Quaternion.Euler(-90,0,0));
				}
				if(level == 2){
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0.5f), Quaternion.Euler(-90,0,0));
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,-0.5f), Quaternion.Euler(-90,0,0));
				}
				if(level >= 3){
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0.25f), Quaternion.Euler(-90,0,0));
					Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,-0.25f), Quaternion.Euler(-90,0,0));
					FIXME_VAR_TYPE custom1= Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,0.5f), Quaternion.Euler(-90,0,0));
					FIXME_VAR_TYPE custom2= Instantiate(bullet1, transform.position+Vector3(0.5f,-0.1f,-0.5f), Quaternion.Euler(-90,0,0));
					custom1.transform.rigidbody.velocity.z = 3;
					custom2.transform.rigidbody.velocity.z = -3;
				}
				//play the bullet sound
				audio.PlayOneShot(shotSound);
				//we want to reset the counter so that our fire rate always applies
				counter = 0.0f;
			}
		}
		#endif
		
		//end of function update
	}
	
	//we receive this message from experience manager that our level has gone up one, so we match it here to allow for our weapons to change.
	void  levelup ( int lvlNumber  ){
		level = lvlNumber;
		//every time we level up once, the firerate speed is increased by 0.5f.
		fireRate += 0.5f;
	}
}