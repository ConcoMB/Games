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
		foreach (GameObject pickup in GameObject.FindGameObjectsWithTag("PickUpZone")) {
			pickup.renderer.enabled = false;
		}
		GameObject[] drops = GameObject.FindGameObjectsWithTag ("DropZone");
		int i = Random.Range (0, drops.Length);
		theDropZone = drops [i];
		theDropZone.renderer.enabled = true;
		GameObject.Find("LevelManager").SendMessage("BeginPickUp", theDropZone, SendMessageOptions.DontRequireReceiver);
	}

	void PickUpModeOff() {
		if (!isInPickupMode) {
			return;
		}
		isInPickupMode = false;	
		theDropZone.renderer.enabled = false;
		foreach (GameObject pickup in GameObject.FindGameObjectsWithTag("PickUpZone")) {
			pickup.renderer.enabled = true;
		}
		GameObject.Find ("LevelManager").SendMessage ("EndPickUp", SendMessageOptions.DontRequireReceiver);
	}
}
