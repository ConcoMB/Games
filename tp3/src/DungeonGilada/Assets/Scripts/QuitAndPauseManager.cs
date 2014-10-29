using UnityEngine;
using System.Collections;

public class QuitAndPauseManager : MonoBehaviour {

	public Font font; 

	private bool isQPressed = false;
	private bool isPaused = false;
	private GUIStyle style;
	private float oldTimeScale;

	void Start() {
		style = new GUIStyle ();
		style.fontSize = 40;
		style.font = font;
		style.normal.textColor = Color.white;
	}
	
	void Update() {
		if (Input.GetKeyDown (KeyCode.P) && ! isQPressed) {
			if (isPaused) {
				unpause();
			} else {
				pause();
			}
			isPaused = !isPaused;
		}
		else if (Input.GetKeyDown (KeyCode.Q) && !isPaused) {
			if (isQPressed) {
				isQPressed = false;
				unpause();
			} else {
				isQPressed = true;
				pause();
			}
		}
		else if (Input.GetKeyDown (KeyCode.N) && isQPressed) {
			isQPressed = false;
			unpause ();
		}
		else if (Input.GetKeyDown (KeyCode.Y) && isQPressed && !isPaused) {
			Application.LoadLevel("Menu");
			unpause();
		}
	}

	void pause() {
		oldTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}

	void unpause() {
		Time.timeScale = oldTimeScale;
	}

	public bool IsPaused() {
		return isPaused || isQPressed;
	}

	void OnGUI (){
		if (isPaused) {
			GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.2f, 100, 50), "Paused", style);
		} else if (isQPressed) {	
			GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.2f, 100, 50), "Quit? Y/N", style);
		}
	}
}
