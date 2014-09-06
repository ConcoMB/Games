using UnityEngine;
using System.Collections;

public class PickUpZone : MonoBehaviour {
	
	private bool isInBox;

	void OnTriggerEnter (Collider other) {
		isInBox = true;
	}

	void OnTriggerExit (Collider other) {
		isInBox = false;
	}
	
	void Update() {
		if (isInBox && Input.GetKey("space")) {
			GameObject car = GameObject.FindGameObjectWithTag("Player");
			if (car.rigidbody.velocity.magnitude < 0.05) {
				GameObject.Find("PickUpManager").SendMessage("PickUpModeOn", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
