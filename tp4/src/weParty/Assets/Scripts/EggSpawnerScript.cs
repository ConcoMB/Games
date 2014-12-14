using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EggSpawnerScript : MonoBehaviour {

    public Transform eggPrefab;

    private float nextEggTime = 0.0f;
    private float spawnRate = 1.5f;
	private int spawned = 0;

	public Queue<GameObject>  eggPool = new Queue<GameObject>(); 

	void Update () {
        if (nextEggTime < Time.time)
        {
            SpawnEgg();
            nextEggTime = Time.time + spawnRate;
            spawnRate *= 0.9f;
            spawnRate = Mathf.Clamp(spawnRate, 0.3f, 99f);
        }
	}

    void SpawnEgg()
    {
        float addXPos = Random.Range(-1.6f, 1.6f);
        Vector3 spawnPos = transform.position + new Vector3(addXPos,0,0);
		if(eggPool.Count == 0) {
        	Instantiate(eggPrefab, spawnPos, Quaternion.identity);
			Debug.Log("SPAWN " + spawned++);
		} else {
			Debug.Log(eggPool.Count);
			GameObject egg = eggPool.Dequeue();
			egg.transform.position = spawnPos;
			egg.GetComponent<EggScript> ().removed = false;
			egg.rigidbody.velocity = new Vector3(0, 0, 0);
		}
    }
}
