using UnityEngine;
using System.Collections;

public class GameLoading : MonoBehaviour {

	public Font font;
	
	private GUIStyle titleStyle;

	void Start(){
		titleStyle = new GUIStyle ();
		titleStyle.fontSize = 40;
		titleStyle.font = font;
		titleStyle.normal.textColor = Color.red;
	}
	
	void OnGUI(){

		GUI.Label (new Rect (Screen.width / 2f - 100, Screen.height / 2f, 400, 200), 
		           "Loading...", 
		           titleStyle);
	}
}