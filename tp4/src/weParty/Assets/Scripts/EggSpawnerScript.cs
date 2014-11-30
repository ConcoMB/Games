using UnityEngine;
using System.Collections;

public class EggSpawnerScript : MonoBehaviour {

    public Transform eggPrefab;

    private float nextEggTime = 0.0f;
    private float spawnRate = 1.5f;
 	
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
        Instantiate(eggPrefab, spawnPos, Quaternion.identity);
    }
}
