using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Font font;
	
	private GUIStyle playStyle;
	private GUIStyle instructionStyle;

	void Start(){
		playStyle = new GUIStyle ();
		playStyle.fontSize = 70;
		playStyle.font = font;
		playStyle.normal.textColor = Color.yellow;
		instructionStyle = new GUIStyle ();
		instructionStyle.fontSize = 20;
		instructionStyle.font = font;
		instructionStyle.normal.textColor = Color.yellow;
	}
	
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width / 2.2f, Screen.height / 3f, 200, 100), "Play", playStyle)){
			Application.LoadLevel("PlayScene");
		}
		GUI.Label (new Rect (Screen.width / 6f, Screen.height / 1.4f, 100, 50), 
		           "Move = arrows / WASD\nBrake = space bar\nPick up / drop = enter\npause = p\nquit = q\nreset position = r", 
		           instructionStyle);
		GUI.Label (new Rect (Screen.width / 1.5f, Screen.height / 1.4f, 100, 50), 
		           "Successfully deliver 5\npassengers\nBe careful, if you runout\nof time on any\ntravel you loose!", 
		           instructionStyle);
	}
}
