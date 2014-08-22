using UnityEngine;
using System.Collections;

public class menuloader : MonoBehaviour {
	
	
	//This is in the Loader scene and will bring us to the menu right away. 
	//This is so we can carry the music manager through the entire game.
	
	void  Start (){
		Application.LoadLevel("menu");
	}
}