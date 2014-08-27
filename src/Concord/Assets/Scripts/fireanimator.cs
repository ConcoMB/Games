using UnityEngine;
using System.Collections;

public class fireanimator : MonoBehaviour {

	public Texture fire1;
	public Texture fire2;
	public Texture fire3;

	private float frameRate = 12.0f;
	private float counter = 0.0f;
	
	void  Update (){
		counter += Time.deltaTime*frameRate;
		if (counter > 0 && renderer.material.mainTexture != fire1) {
			renderer.material.mainTexture = fire1;
		}
		if (counter > 1 && renderer.material.mainTexture != fire2) {
			renderer.material.mainTexture = fire2;
		}
		if (counter > 2 && renderer.material.mainTexture != fire3) {
			renderer.material.mainTexture = fire3;
		}
		if (counter > 3 && renderer.material.mainTexture != fire2) {
			renderer.material.mainTexture = fire2;
		}
		if (counter > 4) {
			counter = 0.0f;
		}
		
	}
}