using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {

	private Texture blankGfx;
	
	void  OnGUI (){
		if(GUI.Button( new Rect(Screen.width / 3,Screen.height / 1.47f,Screen.width / 3,Screen.height / 6), blankGfx, "")) {
			Application.LoadLevel("game2");
		}
	}
}