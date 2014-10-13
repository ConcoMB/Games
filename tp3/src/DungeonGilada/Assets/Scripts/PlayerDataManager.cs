using UnityEngine;
using System.Collections;

public class PlayerDataManager : MonoBehaviour {

	public Font font;
	public GameObject knightGO;
	private GUIStyle style;
	private GUIStyle levelUpStyle;
	private Knight knight;
	private bool levelUp = false;
	public Texture2D aTexture1;
	public Texture2D aTexture2;
	public Texture2D aTexture3;
	public Texture2D aTexture4;
	public Texture2D aTexture5;
	public Texture2D aTexture6;
	public Texture2D aTexture7;
	public Texture2D aTexture8;
	public Texture2D aTexture9;
	public Texture2D aTexture10;


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
//		GUI.Label (new Rect (Screen.width / 9f, Screen.height / 9f, 100, 50), 
//		           "Health: " + knight.health, 
//		           style);
		GUI.DrawTexture(new Rect (Screen.width / 16f, Screen.height / 22f, 400, 50),
		                aTexture10, ScaleMode.ScaleToFit, true, 10.0f);
		if (levelUp) {
			StartCoroutine(WaitLevelUp());
			GUI.Label (new Rect (Screen.width / 2.4f, Screen.height / 2.2f, 200, 100), 
			           "Level up!", 
			           levelUpStyle);
		}
	}

	void UpdateHealth(){
		int diffhelth = knight.health / knight.maxHealth;
		Texture2D aTexture; 
		if (diffhelth == 1) {
			aTexture = aTexture10;
		}else if (diffhelth > 0.9){
			aTexture = aTexture9;
		}else if (diffhelth > 0.8){
			aTexture = aTexture8;
		}else if (diffhelth > 0.7){
			aTexture = aTexture7;
		}else if (diffhelth > 0.6){
			aTexture = aTexture6;
		}else if (diffhelth > 0.5){
			aTexture = aTexture5;
		}else if (diffhelth > 0.4){
			aTexture = aTexture4;
		}else if (diffhelth > 0.3){
			aTexture = aTexture3;
		}else if (diffhelth > 0.2){
			aTexture = aTexture2;
		}else{
			aTexture = aTexture1;
		}
		GUI.DrawTexture(new Rect (Screen.width / 9f, Screen.height / 9f, 100, 50),
		                aTexture, ScaleMode.ScaleToFit, true, 10.0f);
	}

	IEnumerator WaitLevelUp() {
		yield return new WaitForSeconds(3.0f);
		levelUp = false;

	}

	void LevelUp() {
		levelUp = true;
	}
}
