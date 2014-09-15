using UnityEngine;
using System.Collections;

public class PickUpZone : MonoBehaviour {
	
	private bool isInBox;

	void OnTriggerEnter (Collider other) {
		if (other.transform.root.tag == "Player") {
			isInBox = true;
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.transform.root.tag == "Player") {
			isInBox = false;
		}
	}

	void Start() {
		rigidbody.angularVelocity = new Vector3 (0, 10, 0);
	}
	
	void Update() {
		if (isInBox && Input.GetKeyDown(KeyCode.Return)) {
			GameObject car = GameObject.FindGameObjectWithTag("Player");
			if (car.rigidbody.velocity.magnitude < 0.05) {
				GameObject.Find("PickUpManager").SendMessage("PickUpModeOn", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
