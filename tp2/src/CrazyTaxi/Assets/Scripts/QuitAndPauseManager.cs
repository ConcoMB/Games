using UnityEngine;
using System.Collections;

public class QuitAndPauseManager : MonoBehaviour {

	public GameObject player;
	public GameObject levelManager;

	private bool isQPressed = false;
	private GUIStyle style;
	private bool isPaused = false;
	private float oldTimeScale;

	void Start() {
		style = new GUIStyle ();
		style.fontSize = 40;
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
		if (Input.GetKeyDown (KeyCode.Q) && !isPaused) {
			if (isQPressed) {
				isQPressed = false;
				unpause();
			} else {
				isQPressed = true;
				pause();
			}
		}
		if (Input.GetKeyDown (KeyCode.N) && !isPaused) {
			isQPressed = false;
			unpause();
		}
		if (Input.GetKeyDown (KeyCode.Y) && isQPressed && !isPaused) {
			Application.LoadLevel("mainMenu");
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
	
	void OnGUI (){
		if (isPaused) {
			GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.2f, 100, 50), "Paused", style);
		} else if (isQPressed) {	
			GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.2f, 100, 50), "Quit? Y/N", style);
		}
	}
}
