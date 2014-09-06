using UnityEngine;
using System.Collections;

public class PickUpManager : MonoBehaviour {

	private bool isInPickupMode;
	private GameObject theDropZone;

	void Start() {
		isInPickupMode = false;	
		foreach (GameObject pickup in GameObject.FindGameObjectsWithTag("DropZone")) {
			pickup.renderer.enabled = false;
		}
	}

	void PickUpModeOn() {
		if (isInPickupMode) {
			return;
		}
		isInPickupMode = true;		
		Debug.Log ("isinpickup: " + isInPickupMode);
		foreach (GameObject pickup in GameObject.FindGameObjectsWithTag("PickUpZone")) {
			pickup.renderer.enabled = false;
		}
		GameObject[] drops = GameObject.FindGameObjectsWithTag ("DropZone");
		int i = Random.Range (0, drops.Length);
		theDropZone = drops [i];
		theDropZone.renderer.enabled = true;
	}

	void PickUpModeOff() {
		Debug.Log ("holis: " + isInPickupMode);

		if (!isInPickupMode) {
			return;
		}
		isInPickupMode = false;	
		theDropZone.renderer.enabled = false;
		foreach (GameObject pickup in GameObject.FindGameObjectsWithTag("PickUpZone")) {
			pickup.renderer.enabled = true;
		}
	}
}
