using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	
	
	//we create a blank texture that actually has no texture attached so we can hide unity's generic button graphics. they are added to the buttons below to do this.
	private Texture blankGfx;
	
	void  OnGUI (){
		//Play 2 Axis
		if(GUI.Button( new Rect(Screen.width/3,Screen.height/1.47f,Screen.width/3,Screen.height/6), blankGfx, "")){
			Application.LoadLevel("game2");
		}
	}
}