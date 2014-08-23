using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {

	private bool isPaused = false;
	private float originalTimeScale;

	public GUIText pauseText;

	void Start() {
		originalTimeScale = Time.timeScale;
		pauseText.enabled = false;
	}

	void Update() {
		if (Input.GetKeyDown ("p")) {
			if (isPaused) {
				Time.timeScale = this.originalTimeScale;
				pauseText.enabled = false;
			} else {
				Time.timeScale = 0;
				pauseText.enabled = true;
			}
			isPaused = !isPaused;
		}
	}
}
