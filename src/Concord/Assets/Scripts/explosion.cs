using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
	
	public Texture fire0;
	public Texture fire1;
	public Texture fire2;
	public Texture fire3;
	public Texture fire4;
	public Texture fire5;
	public Texture fire6;
	public AudioClip explodeSound;

	private Texture blankTexture;
	private float counter = 0.0f;
	private float frameRate = 16.0f;
	
	void  Start (){
		audio.PlayOneShot(explodeSound);
	}
	
	void  Update (){
		counter += Time.deltaTime*frameRate;
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
		if(counter > frameRate * 1.5f){
			Destroy(gameObject);
		}
	}
}