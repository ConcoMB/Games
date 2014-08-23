using UnityEngine;
using System.Collections;

public class fireanimator : MonoBehaviour {
	
	
	//these are the textures we use to create the flame animation behind the ship so it looks like the engine's fire exhaust.
	public Texture fire1;
	public Texture fire2;
	public Texture fire3;
	
	//private variables that keep track of time for the animation
	private float frameRate = 12.0f;
	private float counter = 0.0f;
	
	void  Update (){
		//counter based on time multiplied by framerate set in private variable. in this example the fire animates at 12 frames a second.
		counter += Time.deltaTime*frameRate;
		//here we do the animating based on time.
		if(counter > 0 && renderer.material.mainTexture != fire1){
			renderer.material.mainTexture = fire1;
		}
		if(counter > 1 && renderer.material.mainTexture != fire2){
			renderer.material.mainTexture = fire2;
		}
		if(counter > 2 && renderer.material.mainTexture != fire3){
			renderer.material.mainTexture = fire3;
		}
		if(counter > 3 && renderer.material.mainTexture != fire2){
			renderer.material.mainTexture = fire2;
		}
		if(counter > 4){
			//here we reset the counter so that the animation can loop infinitely
			counter = 0.0f;
		}
		
	}
}