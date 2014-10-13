using UnityEngine;
using System.Collections;

public class PlayerDataManager : MonoBehaviour {

	public Font font;
	public GameObject knightGO;
	
	private GUIStyle style;

	private Knight knight;

	void Start(){
		knight = knightGO.GetComponent<Knight>();
		style = new GUIStyle ();
		style.fontSize = 30;
		style.font = font;
		style.normal.textColor = Color.white;
	}
	
	void OnGUI(){
		GUI.Label (new Rect (Screen.width / 1.2f, Screen.height / 8f, 100, 50), 
		           "Gold: " + knight.gold, 
		           style);
		GUI.Label (new Rect (Screen.width / 1.2f, Screen.height / 15f, 100, 50), 
		           "Level: " + knight.level, 
		           style);
	}

	void LevelUp() {

	}
}
