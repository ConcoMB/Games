using UnityEngine;
using System.Collections;

public class ResetManager : MonoBehaviour {
	
	public GameObject player;
	public Font font;
	public GameObject pointsManager;
	public GameObject quitAndPauseManager;

	private bool isRPressed = false;
	private GUIStyle style;
	private Vector3 startingPosition;
	private Quaternion startingRotation;
	private QuitAndPauseManager quitAndPauseManagerScript;

	void Start() {
		startingPosition = player.transform.position;
		startingRotation = player.transform.rotation;
		style = new GUIStyle ();
		style.fontSize = 40;
		style.font = font;
		style.normal.textColor = Color.white;
		quitAndPauseManagerScript = (QuitAndPauseManager)quitAndPauseManager.GetComponent<QuitAndPauseManager> ();
	}
	
	void Update() {
		if (quitAndPauseManagerScript.IsPaused ()) {
				return;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			if (isRPressed) {
				isRPressed = false;
			} else {
				isRPressed = true;
			}
		}
		else if (Input.GetKeyDown (KeyCode.N)) {
			isRPressed = false;
		}
		else if (Input.GetKeyDown (KeyCode.Y) && isRPressed) {
			player.transform.position = startingPosition;
			player.transform.rotation = startingRotation;
			pointsManager.SendMessage("NotifyReset", SendMessageOptions.DontRequireReceiver);
			isRPressed = false;
		}
		
	}	

	void OnGUI (){
		if (isRPressed) {	
			GUI.Label (new Rect (Screen.width / 2.2f, Screen.height / 2.2f, 100, 50), "Reset? y/n", style);
		}
	}
}
