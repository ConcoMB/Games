using UnityEngine;
using System.Collections;

public class playeranimator : MonoBehaviour {

	public Texture shipUp;
	public Texture shipIdle;
	public Texture shipDown;
	private GameObject mainCamera;
	
	void  Start (){
		mainCamera = GameObject.Find("Main Camera");
	}
	
	void  Update (){
		if(rigidbody.velocity.z == 0 && renderer.material.mainTexture != shipIdle){
			renderer.material.mainTexture = shipIdle;
		}
		if(rigidbody.velocity.z > 0 && renderer.material.mainTexture != shipUp){
			renderer.material.mainTexture = shipUp;
		}
		if(rigidbody.velocity.z < 0 && renderer.material.mainTexture != shipDown){
			renderer.material.mainTexture = shipDown;
		}
	}
}