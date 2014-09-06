using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	private int successfulTravels;
	private float time;
	private bool isInPlay;
	private bool lost;
	private GUIStyle lostStyle;
	private GUIStyle timeStyle;

	void Start() {
		lostStyle = new GUIStyle ();
		lostStyle.fontSize = 40;
		lostStyle.normal.textColor = Color.white;
		timeStyle = new GUIStyle ();
		timeStyle.fontSize = 20;
		timeStyle.normal.textColor = Color.white;
	}

	void Update () {
		if (!isInPlay) {
			return;
		}
		time -= Time.deltaTime;
		if (time >= 0) {
			return;
		}
		time = 0;
		lost = true;
	}
	
	void BeginPickUp (GameObject drop) {
		if (isInPlay) {
			return;
		}
		isInPlay = true;
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		time = Vector3.Distance (player.rigidbody.position, drop.transform.position);
	}

	void EndPickUp() {
		isInPlay = false;
		if (time > 0) {
			successfulTravels++;
		}
	}

	void OnGUI (){
		if (lost) {
			GUI.Label(new Rect(Screen.width / 2.2f, Screen.height / 2.2f,100,50), "You lost!", lostStyle);
			StartCoroutine(Wait());
			return;
		}
		GUI.Label(new Rect(Screen.width / 10, Screen.height / 10  - 50, 100, 50), "Successful travels: " + successfulTravels, timeStyle);
		if (!isInPlay) {
			return;
		}
		GUI.Label(new Rect(Screen.width / 10, Screen.height / 10, 100, 50), "Time Left: " + time, timeStyle);
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(3.0f);
		string lvlName = Application.loadedLevelName;
		Application.LoadLevel(lvlName);
	}
}
