using UnityEngine;
using System.Collections;

public class ResetManager : MonoBehaviour {
	
	public GameObject player;
	
	private bool isRPressed = false;
	private GUIStyle style;
	private bool isPaused = false;

	Vector3 startingPosition;
	Quaternion startingRotation;

	void Start() {
		startingPosition = player.transform.position;
		startingRotation = player.transform.rotation;
		style = new GUIStyle ();
		style.fontSize = 40;
		style.normal.textColor = Color.white;
		
	}
	
	void Update() {
		if (Input.GetKeyDown (KeyCode.R) && !isPaused) {
			if (isRPressed) {
				isRPressed = false;
				unpause();
			} else {
				isRPressed = true;
				pause();
			}
		}
		if (Input.GetKeyDown (KeyCode.N) && !isPaused) {
			isRPressed = false;
			unpause();
		}
		if (Input.GetKeyDown (KeyCode.Y) && isRPressed && !isPaused) {
			player.transform.position = startingPosition;
			player.transform.rotation = startingRotation;
			isRPressed = false;
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
		if (isRPressed) {	
			GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.2f, 100, 50), "Reset? y/n", style);
		}
	}
}
