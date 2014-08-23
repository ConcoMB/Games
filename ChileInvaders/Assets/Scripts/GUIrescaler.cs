using UnityEngine;
using System.Collections;

public class GUIrescaler : MonoBehaviour {

	//here is a special gui rescaler that automatically rescales GUIText and GUITextures so they're not stretched.
	
	private Component getTxt;
	private Component getTxtr;
	private float resX;
	private float resY;
	private float origResX;
	private float origResY;
	private float txtrX;
	private float txtrY;
	private float txtX;
	private float txtY;
	
	void  Start (){
		getTxt = transform.GetComponent<GUIText>();
		getTxtr = transform.GetComponent<GUITexture>();
		if(getTxtr == null && getTxt == null){
			print("No GUIText or GUITexture exists on: " + transform.gameObject.name);
		}
		
	}
	
	void  Update (){
		
		if(Screen.width != origResX || Screen.height != origResY){
			
			origResX = Screen.width;
			origResY = Screen.height;
			
			if(getTxt != null){
				resX = Screen.width;
				resY = Screen.height;
				txtX = transform.localScale.x;
				txtY = transform.localScale.y;
				transform.localScale = new Vector2(transform.localScale.x, transform.localScale.x*(resX/resY));
			}
			if(getTxtr != null){
				resX = Screen.width;
				resY = Screen.height;
				txtrX = transform.guiTexture.texture.width;
				txtrY = transform.guiTexture.texture.height;
				transform.localScale = new Vector2(transform.localScale.x, transform.localScale.x*(resX/resY))/(txtrX/txtrY);
			}
		}
		
	}
}