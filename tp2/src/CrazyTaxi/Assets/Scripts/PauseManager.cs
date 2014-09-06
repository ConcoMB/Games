using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {
	
	private bool isPaused = false;
	private float originalTimeScale;
	private GUIStyle pauseStyle;
	
	void Start() {
		originalTimeScale = Time.timeScale;
		pauseStyle = new GUIStyle ();
		pauseStyle.fontSize = 40;
		pauseStyle.normal.textColor = Color.white;
	}
	
	void Update() {
		if (Input.GetKeyDown ("p")) {
			if (isPaused) {
				Time.timeScale = this.originalTimeScale;
			} else {
				Time.timeScale = 0;
			}
			isPaused = !isPaused;
		}
	}

	void OnGUI (){
		if (!isPaused) {
			return;
		}
		GUI.Label(new Rect(Screen.width / 2.2f, Screen.height / 2.2f,100,50), "Paused", pauseStyle);
	}
}