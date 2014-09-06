using UnityEngine;
using System.Collections;

public class QuitAndPauseManager : MonoBehaviour {

	private bool isQPressed = false;
	private float originalTimeScale;
	private GUIStyle style;
	private bool isPaused = false;

	void Start() {
		originalTimeScale = Time.timeScale;
		style = new GUIStyle ();
		style.fontSize = 40;
		style.normal.textColor = Color.white;
	}
	
	void Update() {
		if (Input.GetKeyDown ("p") && ! isQPressed) {
			if (isPaused) {
				Time.timeScale = this.originalTimeScale;
			} else {
				Time.timeScale = 0;
			}
			isPaused = !isPaused;
		}
		if (Input.GetKeyDown ("q") && !isPaused) {
			if (isQPressed) {
				isQPressed = false;
				Time.timeScale = this.originalTimeScale;
			} else {
				isQPressed = true;
				Time.timeScale = 0;
			}
		}
		if (Input.GetKeyDown ("n") && !isPaused) {
			isQPressed = false;
			Time.timeScale = this.originalTimeScale;
		}
		if (Input.GetKeyDown ("y") && isQPressed && !isPaused) {
			Application.LoadLevel("mainMenu");
			Time.timeScale = this.originalTimeScale;
		}
	}
	
	void OnGUI (){
		if (isPaused) {
			GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.2f, 100, 50), "Paused", style);
		} else if (isQPressed) {	
			GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.2f, 100, 50), "Quit? y/n", style);
		}
	}
}
