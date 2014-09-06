using UnityEngine;
using System.Collections;

public class QuitManager : MonoBehaviour {

	private bool isQPressed = false;
	private float originalTimeScale;
	private GUIStyle style;
	
	void Start() {
		originalTimeScale = Time.timeScale;
		style = new GUIStyle ();
		style.fontSize = 40;
		style.normal.textColor = Color.white;
	}
	
	void Update() {
		if (Input.GetKeyDown ("q")) {
			isQPressed = true;
			Time.timeScale = 0;
		}
		if (Input.GetKeyDown ("n")) {
			isQPressed = false;
			Time.timeScale = this.originalTimeScale;
		}
		if (Input.GetKeyDown ("y") && isQPressed) {
			Application.LoadLevel("mainMenu");
			Time.timeScale = this.originalTimeScale;
		}
	}
	
	void OnGUI (){
		if (!isQPressed) {
			return;
		}
		GUI.Label(new Rect(Screen.width / 2.2f, Screen.height / 2.2f,100,50), "Quit? y/n", style);
	}
}
