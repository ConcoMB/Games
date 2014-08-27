// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class enemyspawner : MonoBehaviour {

	public int maxLevel;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject boss;
	public GUIText wonMessage;
	public float maxHeight = 6.0f;
	public float minHeight = -6.0f;
	
	private float counter = 0.0f;
	private GameObject player;
	private int randomChoice;
	private float spawnRate = 2.0f;
	private int level = 1;

	void Start() {
		wonMessage.enabled = false;
	}

	void  Update (){
		counter += Time.deltaTime;
		if(spawnRate > 0.33f){
			spawnRate -= Time.deltaTime/80;
		}
		if (counter <= spawnRate) {
				return;
		}
		randomChoice = Random.Range(1,6);
		if (level < maxLevel) {
			if(level < 2 || randomChoice >= 1 && randomChoice <= 3){
				Instantiate(enemy1, new Vector3(transform.position.x, 0, Random.Range(minHeight,maxHeight)),
				            Quaternion.Euler(-90, 0, 0));
			} else if(level < 3 || randomChoice == 4) {
				Instantiate(enemy2, new Vector3(transform.position.x, 0, Random.Range(minHeight / 3, maxHeight / 3)), 
				            Quaternion.Euler(-90, 0, 0));
			} else if(randomChoice == 5) {
				Instantiate(enemy3, new Vector3(transform.position.x, 0, Random.Range(minHeight,maxHeight)),
				            Quaternion.Euler(-90, 90, 0));
			}
		}
		counter = 0.0f;
	}

	void win() {
		wonMessage.enabled = true;
		foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("enemybullet")) {
			Destroy(bullet);
		}
		StartCoroutine(Wait());
	}

	void levelup(int lvlNumber){
		level = lvlNumber;
		if (level == maxLevel) {
			Instantiate(boss, new Vector3(transform.position.x, 0 , 0), Quaternion.Euler(-90,0,0));
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel("menu");
	}
}