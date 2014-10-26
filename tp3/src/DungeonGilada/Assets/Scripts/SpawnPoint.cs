using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	public GameObject[] spawnObjects; 
	public float probability;

	// Use this for initialization
	void Start () {
		if (Random.value < probability) {
			int index = Random.Range(0, spawnObjects.Length);
			Debug.Log (index);
			GameObject spawned = (GameObject) Instantiate (spawnObjects[index], transform.position, spawnObjects[index].transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
