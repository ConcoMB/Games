using UnityEngine;
using System.Collections;

public class Results : MonoBehaviour {

	private GUIStyle style;
	private GUIStyle buttonStyle;

	public Font font;

	// Use this for initialization
	void Start () {
		style = new GUIStyle ();
		style.fontSize = 40;
		style.font = font;
		style.normal.textColor = Color.white;
		buttonStyle = new GUIStyle ();
		buttonStyle.fontSize = 40;
		buttonStyle.font = font;
		buttonStyle.normal.textColor = Color.red;
	}

	void OnGUI(){
		GUI.Label (new Rect (Screen.width / 2 - 100, 100, Screen.width, Screen.height), 
		           "RESULTS", 
		           style);

		if (Game.winner == Game.Player.HUMAN) {
			GUI.Label (new Rect (100, 200, Screen.width, Screen.height), 
           "1. Human: " + Game.HumanPoints + " points", 
           style);

			GUI.Label (new Rect (100, 300, Screen.width, Screen.height), 
           "2. Orc: " + Game.OrcPoints + " points", 
           style);
		} else {
			GUI.Label (new Rect (100, 300, Screen.width, Screen.height), 
			           "2. Human: " + Game.HumanPoints + " points", 
			           style);
			
			GUI.Label (new Rect (100, 200, Screen.width, Screen.height), 
			           "1. Orc: " + Game.OrcPoints + " points", 
			           style);
		}
		if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height - 100, 600, 600), 
		              "BACK TO BOARD", 
		              buttonStyle)){
			Application.LoadLevel("Board");
		}
	}

}
