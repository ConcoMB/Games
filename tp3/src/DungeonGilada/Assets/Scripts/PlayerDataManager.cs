using UnityEngine;
using System.Collections;

public class PlayerDataManager : MonoBehaviour {

	public Font font;
	public GameObject knightGO;
	private GUIStyle style;
	private GUIStyle levelUpStyle;
	private Knight knight;
	private bool levelUp = false;

	public Texture2D barBack;
	public Texture2D barFront;

	void Start(){
		knight = knightGO.GetComponent<Knight>();
		style = new GUIStyle ();
		style.fontSize = 30;
		style.font = font;
		style.normal.textColor = Color.white;
		levelUpStyle = new GUIStyle ();
		levelUpStyle.fontSize = 60;
		levelUpStyle.font = font;
		levelUpStyle.normal.textColor = Color.white;
	}
	
	void OnGUI(){
		GUI.Label (new Rect (Screen.width / 1.2f, Screen.height / 8f, 100, 50), 
		           "Gold: " + knight.gold, 
		           style);
		GUI.Label (new Rect (Screen.width / 1.2f, Screen.height / 15f, 100, 50), 
		           "Level: " + knight.level, 
		           style);

		GUI.BeginGroup (new Rect (Screen.width / 40f - 40f, Screen.height / 40f, 500 , 70));

			GUI.DrawTexture (new Rect (Screen.width / 16f, Screen.height / 22f, 400 , 50), barBack);
			float diffhelth = (float)knight.health / (float)knight.maxHealth;

			GUI.BeginGroup (new Rect (Screen.width / 600f, Screen.height / 65f, 500 * diffhelth, 50));
				GUI.DrawTexture (new Rect (Screen.width / 16f, Screen.height / 22f, 400 , 50), barFront);
			GUI.EndGroup();

		GUI.EndGroup();


		if (levelUp) {
			StartCoroutine(WaitLevelUp());
			GUI.Label (new Rect (Screen.width / 2.4f, Screen.height / 2.2f, 200, 100), 
			           "Level up!", 
			           levelUpStyle);
		}
	}


	IEnumerator WaitLevelUp() {
		yield return new WaitForSeconds(3.0f);
		levelUp = false;

	}

	void LevelUp() {
		levelUp = true;
	}
}
