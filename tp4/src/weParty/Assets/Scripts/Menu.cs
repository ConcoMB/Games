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
		playStyle.normal.textColor = Color.red;
		titleStyle = new GUIStyle ();
		titleStyle.fontSize = 70;
		titleStyle.font = font;
		titleStyle.normal.textColor = Color.blue;
	}
	
	void OnGUI(){
		if(GUI.Button(new Rect(100, Screen.height - 100, 600, 100), "Play vs CPU", playStyle)){
			Application.LoadLevel("Game");
		}
		if(GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height - 100, 200, 100), "Play vs friends", playStyle)){
//			Application.LoadLevel("Game");
		}
		if(GUI.Button(new Rect(Screen.width - 400, Screen.height - 100, 200, 100), "Top players", playStyle)){
//			Application.LoadLevel("Game");
		}
		GUI.Label (new Rect (Screen.width / 2f - 200, 50, 400, 200), 
		           "WE PARTY", 
		           titleStyle);
	}
}
