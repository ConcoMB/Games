using UnityEngine;
using System.Collections;

public class PlayerDataManager : MonoBehaviour {

	public Font font;
	
	private GUIStyle style;
	private int gold = 0;

	void Start(){
		style = new GUIStyle ();
		style.fontSize = 30;
		style.font = font;
		style.normal.textColor = Color.white;
	}
	
	void OnGUI(){
		GUI.Label (new Rect (Screen.width / 1.2f, Screen.height / 15f, 100, 50), 
		           "Gold: " + gold, 
		           style);
	}

	void EarnGold(int earnGold) {
		gold += earnGold;
	}
}
