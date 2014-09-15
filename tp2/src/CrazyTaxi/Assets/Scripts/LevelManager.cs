using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public int winAmount = 5;
	public Font font;
	private int successfulTravels;
	private float time;
	private bool isInPlay;
	private bool lost;
	private bool won;
	private GUIStyle lostStyle;
	private GUIStyle timeStyle;

	void Start() {
		lostStyle = new GUIStyle ();
		lostStyle.fontSize = 40;
		lostStyle.normal.textColor = Color.white;		
		lostStyle.font = font;

		timeStyle = new GUIStyle ();
		timeStyle.font = font;
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
		time = (Vector3.Distance (player.rigidbody.position, drop.transform.position)) * (winAmount - successfulTravels) / winAmount;
	}

	void EndPickUp() {
		isInPlay = false;
		if (time > 0) {
			successfulTravels++;
		}
		if (successfulTravels == winAmount) {
			won = true;
		}
	}

	void OnGUI (){
		if (won) {
			GUI.Label(new Rect(Screen.width / 2.2f, Screen.height / 2.2f,100,50), "You won!", lostStyle);
			StartCoroutine(Wait());
			return;
		}
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
		Application.LoadLevel("mainMenu");
	}
}
