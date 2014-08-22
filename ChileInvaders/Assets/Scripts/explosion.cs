using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
	
	
	//this script animates the explosion that happens only one time before its destroyed
	
	//here are the public variables that can be accessed in the inspector. the explosion animation uses 7 textures.
	public Texture fire0;
	public Texture fire1;
	public Texture fire2;
	public Texture fire3;
	public Texture fire4;
	public Texture fire5;
	public Texture fire6;
	//the explosion sound
	public AudioClip explodeSound;
	
	//private variables that this script keeps track of to do the explosion animation
	private Texture blankTexture;
	private float counter = 0.0f;
	private float frameRate = 32.0f;
	
	void  Start (){
		//play the sound once the explosion is spawned
		audio.PlayOneShot(explodeSound);
	}
	
	void  Update (){
		//keep track of time based on the frameRate speed we chose in the private variable. default is 32, but can be changed to anything to change the speed of the animation
		counter += Time.deltaTime*frameRate;
		
		//here we change the explosion texture based on the counter
		if(counter > 0 && renderer.material.mainTexture != fire0){
			renderer.material.mainTexture = fire0;
		}
		if(counter > 1 && renderer.material.mainTexture != fire1){
			renderer.material.mainTexture = fire1;
		}
		if(counter > 2 && renderer.material.mainTexture != fire2){
			renderer.material.mainTexture = fire2;
		}
		if(counter > 3 && renderer.material.mainTexture != fire3){
			renderer.material.mainTexture = fire3;
		}
		if(counter > 4 && renderer.material.mainTexture != fire4){
			renderer.material.mainTexture = fire4;
		}
		if(counter > 5 && renderer.material.mainTexture != fire5){
			renderer.material.mainTexture = fire5;
		}
		if(counter > 6 && renderer.material.mainTexture != fire6){
			renderer.material.mainTexture = fire6;
		}
		if(counter > 7 && renderer.material.color.a != 0.0f){
			renderer.material.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
		}
		//if the counter is higher than framerate*1.5f, we destroy the explosion animation object. This is so the sound can play before its destroyed since an audio source is attached.
		if(counter > frameRate*1.5f){
			Destroy(gameObject);
		}
		
	}
}