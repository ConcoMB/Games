using UnityEngine;
using System.Collections;

public class EggScript : MonoBehaviour {

	private EggSpawnerScript eggSpawner;
	public bool removed = false;
	
	void Start() {
		eggSpawner = GameObject.FindGameObjectWithTag("EggSpawner").GetComponent<EggSpawnerScript> ();
	}

	void Update () {
		if(!removed) {
	        if (transform.position.y <= -2 || transform.position.y >= 22) {
				eggSpawner.eggPool.Enqueue (gameObject);
				removed = true;
			} else {
				float fallSpeed = 2 * Time.deltaTime;
				transform.position -= new Vector3 (0, fallSpeed, 0);
			}
		}
	}
}
