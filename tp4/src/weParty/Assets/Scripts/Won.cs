using UnityEngine;
using System.Collections;

public class Won : MonoBehaviour {
		
	private GUIStyle bigStyle;
	private GUIStyle mediumStyle;
	private GUIStyle smallStyle;
	public GameObject orc;
	public GameObject human;
	public Font font;

	// Use this for initialization
	void Start () {
		bigStyle = new GUIStyle ();
		bigStyle.fontSize = 60;
		bigStyle.font = font;
		bigStyle.normal.textColor = Color.white;

		mediumStyle = new GUIStyle ();
		mediumStyle.fontSize = 30;
		mediumStyle.font = font;
		mediumStyle.normal.textColor = Color.yellow;
		
		smallStyle = new GUIStyle ();
		smallStyle.fontSize = 20;
		smallStyle.font = font;
		smallStyle.normal.textColor = Color.yellow;
		if (Game.winner == Game.Player.HUMAN) {
			orc.renderer.enabled = false;
		} else {
			human.renderer.enabled = false;
		}
	}

	void OnGUI(){
		GUI.Label (new Rect (Screen.width / 2 - 200, 100, 200, 100), 
		           (Game.winner == Game.Player.HUMAN ? "Human" : "Orc") + " won!", 
		           bigStyle);
		if(GUI.Button(new Rect(100, Screen.height - 100, 200, 100), "Main Menu", smallStyle)){
			Application.LoadLevel("Menu");
		}
		if(GUI.Button(new Rect(Screen.width - 200, Screen.height - 100, 200, 100), "Play again", smallStyle)){
			Application.LoadLevel("Game");
		}
		if(GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height - 100, 200, 100), "Share your results!", mediumStyle)){
			// not yet
		}
	}

}
