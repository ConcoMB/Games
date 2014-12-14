using UnityEngine;
using System.Collections;

public class EggCollider : MonoBehaviour {

    EggPlayerScript myPlayerScript;
	private EggSpawnerScript eggSpawner;

	void Start () {
		eggSpawner = GameObject.FindGameObjectWithTag("EggSpawner").GetComponent<EggSpawnerScript> ();
	}

    void Awake()
    {
        myPlayerScript = transform.parent.GetComponent<EggPlayerScript>();
    }

	void OnTriggerEnter(Collider theCollision)
    {
        GameObject collisionGO = theCollision.gameObject;
		eggSpawner.eggPool.Enqueue (collisionGO);
		collisionGO.transform.position = new Vector3(0, 20, 0);

        myPlayerScript.theScore++;
    }
}
