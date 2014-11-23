using UnityEngine;
using System.Collections;

public class PlayerDataManager : MonoBehaviour {

	public bool win;
	public GUIStyle levelUpStyle;
	public Font font;

	void Start () {
		levelUpStyle = new GUIStyle ();
		levelUpStyle.fontSize = 60;
		levelUpStyle.font = font;
		levelUpStyle.normal.textColor = Color.white;
	}
	
	void Update () {
	
	}

	void Win() {
		win = true;
	}

	void OnGUI(){
//		GUI.Label (new Rect (Screen.width / 1.2f, Screen.height / 8f, 100, 50), 
//		           "Gold: " + knight.gold, 
//		           style);
//		GUI.Label (new Rect (Screen.width / 1.2f, Screen.height / 15f, 100, 50), 
//		           "Level: " + knight.level, 
//		           style);
		
		if (win) {
			StartCoroutine(waitToFinish());
			GUI.Label (new Rect (Screen.width / 2.4f, Screen.height / 2.2f, 200, 100), 
			           (Game.winner == Game.Winner.HUMAN ? "Human" : "Orc") + " wins!", 
			           levelUpStyle);
		}
	}

	IEnumerator waitToFinish() {
		yield return new WaitForSeconds(3.0f);
		win = false;
		Application.LoadLevel ("Menu");
	}
}
