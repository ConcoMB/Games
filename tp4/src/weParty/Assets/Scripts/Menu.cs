using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Font font;
	
	private GUIStyle titleStyle;
	private GUIStyle playStyle;
	
	void Start(){
		playStyle = new GUIStyle ();
		playStyle.fontSize = 40;
		playStyle.font = font;
		playStyle.normal.textColor = Color.white;
		titleStyle = new GUIStyle ();
		titleStyle.fontSize = 70;
		titleStyle.font = font;
		titleStyle.normal.textColor = Color.white;
	}
	
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width / 3f, Screen.height / 1.25f, 200, 100), "DARE TO PLAY?", playStyle)){
			Application.LoadLevel("Game");
		}
		GUI.Label (new Rect (Screen.width / 4f, Screen.height / 10f, 100, 50), 
		           "WE PARTY", 
		           titleStyle);
	}
}
