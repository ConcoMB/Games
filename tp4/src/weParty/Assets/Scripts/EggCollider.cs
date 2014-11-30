using UnityEngine;
using System.Collections;

public class EggCollider : MonoBehaviour {

    EggPlayerScript myPlayerScript;

    void Awake()
    {
        myPlayerScript = transform.parent.GetComponent<EggPlayerScript>();
    }

	void OnTriggerEnter(Collider theCollision)
    {
        GameObject collisionGO = theCollision.gameObject;
        Destroy(collisionGO);

        myPlayerScript.theScore++;
    }
}
