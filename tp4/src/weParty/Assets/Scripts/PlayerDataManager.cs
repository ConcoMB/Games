using UnityEngine;
using System.Collections;

public class PlayerDataManager : MonoBehaviour {

	public bool win;
	public GUIStyle levelUpStyle;
	public Font font;

	void Start () {
		levelUpStyle = new GUIStyle ();
		levelUpStyle.fontSize = 60;
		levelUpStyle.font = font;
		levelUpStyle.normal.textColor = Color.white;
	}
	
	void Update () {
		if (win) {
			StartCoroutine (waitToFinish ());
		}
	}

	void Win() {
		win = true;
	}

	IEnumerator waitToFinish() {
		yield return new WaitForSeconds(3.0f);
		win = false;
		Application.LoadLevel ("Menu");
	}
}
