using UnityEngine;
using System.Collections;

public class experiencemanager : MonoBehaviour {

	public int levelUpAmount;
	public GUIText levelText;
	public GUITexture levelBar;
	public GUITexture bar1;
	public AudioClip lvlUpSound;

	private float expAmount = 0.0f;
	private int level = 1;
	
	void  Update(){
		levelBar.transform.localScale = new Vector3(0.24f*(expAmount/(45*level)),bar1.transform.localScale.y,1);
		if (expAmount < (levelUpAmount * level)) {
			return;
		}
		audio.PlayOneShot(lvlUpSound);
		expAmount = 0;
		level += 1;
		levelText.text = "Lvl " + level.ToString();
		SendMessage("levelup", level, SendMessageOptions.DontRequireReceiver);
		GameObject enemyspawner = GameObject.Find("enemyspawner");
		enemyspawner.SendMessage("levelup", level, SendMessageOptions.DontRequireReceiver);
		GameObject stars = GameObject.Find("Stars");
		stars.SendMessage("levelup", level, SendMessageOptions.DontRequireReceiver);
	}
	
	void  OnTriggerEnter ( Collider other  ){
		if(other.name == "exp(Clone)"){
			expAmount += 1;
			Destroy(other.gameObject);
		}
	}
}