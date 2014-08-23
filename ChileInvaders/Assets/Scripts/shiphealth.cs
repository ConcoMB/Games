using UnityEngine;
using System.Collections;

public class shiphealth : MonoBehaviour {

	public GameObject explosion;
	public GUIText gameOverText;
	
	void Start(){
		gameOverText.guiText.enabled = false;
	}

	void OnTriggerEnter( Collider other  ){
		if (other.tag == "enemy" || other.tag == "enemybullet") {
			Instantiate(explosion, transform.position, Quaternion.Euler(-90,Random.Range(-180, 180), 0));
			death();
		}
	}
	
	void death(){
		playercontrols playerControls = gameObject.GetComponent<playercontrols>();
		weaponsystem weaponSystem = gameObject.GetComponent<weaponsystem>();
		GameObject fire = GameObject.Find("fire");
		playerControls.enabled = false;
		weaponSystem.enabled = false;
		fire.renderer.enabled = false;
		collider.enabled = false;
		renderer.material.color = new Color(0,0,0, 0.0f);
		gameOverText.guiText.enabled = true;
		StartCoroutine(Wait());
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(3);
		string lvlName = Application.loadedLevelName;
		Application.LoadLevel(lvlName);
	}
}