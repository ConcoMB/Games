using UnityEngine;
using System.Collections;

public class shiphealth : MonoBehaviour {
	
	
	//are the public variables for ship health that can be accessed in the inspector. we are using the explosion animation object and gameover text for when we die.
	public GameObject explosion;
	public GUIText gameOverText;
	
	void  Start (){
		//make the gameover text not enabled on start so it doesn't say gameover while playing.
		gameOverText.guiText.enabled = false;
	}
	
	//if we're hit by an enemy or bullet, we die. (one hit kill i know, sucks right?)
	void  OnTriggerEnter ( Collider other  ){
		if(other.tag == "enemy" || other.tag == "enemybullet"){
			//here we spawn the explosion animation.
			Instantiate(explosion,transform.position,Quaternion.Euler(-90,Random.Range(-180,180),0));
			death();
		}
	}
	
	//on death we need to do some stuff so the ship can look like it explodes and the gameover text shows up.
	void  death (){
		//here we turn off a bunch of stuff like the renderer and scripts for the ship so its not controllable or viewable by the player anymore, and not able to be hit by enemies.
		playercontrols playerControls= gameObject.GetComponent<playercontrols>();
		weaponsystem weaponSystem= gameObject.GetComponent<weaponsystem>();
		GameObject fire= GameObject.Find("fire");
		playerControls.enabled = false;
		weaponSystem.enabled = false;
		fire.renderer.enabled = false;
		collider.enabled = false;
		renderer.material.color = new Color(0,0,0, 0.0f);
		
		//here we turn the game over text back on
		gameOverText.guiText.enabled = true;
		//here we wait for 3 seconds so the scene doesn't load right away again.
		StartCoroutine(Wait());
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(3);
		//here we find the name of the scene we were just playing, and load it again.
		string lvlName = Application.loadedLevelName;
		Application.LoadLevel(lvlName);
	}
}