using UnityEngine;
using System.Collections;

public class QuitAndPauseManager : MonoBehaviour {

	public GameObject player;

	private bool isQPressed = false;
	private GUIStyle style;
	private bool isPaused = false;

	void Start() {
		style = new GUIStyle ();
		style.fontSize = 40;
		style.normal.textColor = Color.white;
	}
	
	void Update() {
		if (Input.GetKeyDown ("p") && ! isQPressed) {
			if (isPaused) {
				unpause();
			} else {
				pause();
			}
			isPaused = !isPaused;
		}
		if (Input.GetKeyDown ("q") && !isPaused) {
			if (isQPressed) {
				isQPressed = false;
				unpause();
			} else {
				isQPressed = true;
				pause();
			}
		}
		if (Input.GetKeyDown ("n") && !isPaused) {
			isQPressed = false;
			unpause();
		}
		if (Input.GetKeyDown ("y") && isQPressed && !isPaused) {
			Application.LoadLevel("mainMenu");
			unpause();
		}
	}

	void pause() {
		player.SendMessage ("OnPauseGame", SendMessageOptions.DontRequireReceiver);
	}

	void unpause() {
		player.SendMessage ("OnUnpauseGame", SendMessageOptions.DontRequireReceiver);
	}
	
	void OnGUI (){
		if (isPaused) {
			GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.2f, 100, 50), "Paused", style);
		} else if (isQPressed) {	
			GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.2f, 100, 50), "Quit? y/n", style);
		}
	}
}
