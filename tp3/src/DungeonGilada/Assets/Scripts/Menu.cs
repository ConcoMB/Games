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
		playStyle.normal.textColor = Color.yellow;
		titleStyle = new GUIStyle ();
		titleStyle.fontSize = 70;
		titleStyle.font = font;
		titleStyle.normal.textColor = Color.yellow;
	}
	
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 1.25f, 200, 100), "DARE TO PLAY?", playStyle)){
			Application.LoadLevel("Play");
		}
		GUI.Label (new Rect (Screen.width / 3.3f, Screen.height / 10f, 100, 50), 
		           "DUNGEON GILADA", 
		           titleStyle);
	}
}
