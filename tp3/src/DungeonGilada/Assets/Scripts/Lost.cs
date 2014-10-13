using UnityEngine;
using System.Collections;

public class Lost : MonoBehaviour {

	public Font font;

	private GUIStyle style;

	void Start () {
		style = new GUIStyle ();
		style.fontSize = 60;
		style.font = font;
		style.normal.textColor = Color.white;
	}
	
	void OnGUI(){
		GUI.Label (new Rect (Screen.width / 2.4f, Screen.height / 8f, 200, 100), 
		           "You Lost!", 
		           style);
		if(GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 1.25f, 200, 100), "Main menu", style)){
			Application.LoadLevel("Menu");
		}
	}
}
