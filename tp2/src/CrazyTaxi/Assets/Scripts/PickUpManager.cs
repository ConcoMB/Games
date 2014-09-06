using UnityEngine;
using System.Collections;

public class PickUpManager : MonoBehaviour {

	private bool isInPickupMode;

	void pickUpModeOn() {
		isInPickupMode = true;		
		foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("PickUpZone")) {
				}

	}

	void pickUpModeOff() {
		isInPickupMode = false;		
		Debug.Log ("off");
	}
}
