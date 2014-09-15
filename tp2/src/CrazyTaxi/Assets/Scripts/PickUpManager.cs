using UnityEngine;
using System.Collections;

public class PickUpManager : MonoBehaviour {

	public GameObject arrow;

	private bool isInPickupMode;
	private GameObject theDropZone;

	void Start() {
		isInPickupMode = false;	
		foreach (GameObject drop in GameObject.FindGameObjectsWithTag("DropZone")) {
			drop.renderer.enabled = false;
			drop.light.enabled = false;
		}
		arrow.renderer.enabled = false;
	}

	void PickUpModeOn() {
		if (isInPickupMode) {
			return;
		}
		isInPickupMode = true;	
		arrow.renderer.enabled = true;
		Debug.Log ("isinpickup: " + isInPickupMode);
		foreach (GameObject pickup in GameObject.FindGameObjectsWithTag("PickUpZone")) {
			pickup.renderer.enabled = false;
			pickup.light.enabled = false;
		}
		GameObject[] drops = GameObject.FindGameObjectsWithTag ("DropZone");
		int i = Random.Range (0, drops.Length);
		theDropZone = drops [i];
		theDropZone.renderer.enabled = true;
		theDropZone.light.enabled = true;
		GameObject.Find("LevelManager").SendMessage("BeginPickUp", theDropZone, SendMessageOptions.DontRequireReceiver);
	}

	void PickUpModeOff() {
		if (!isInPickupMode) {
			return;
		}
		isInPickupMode = false;	
		arrow.renderer.enabled = false;
		theDropZone.renderer.enabled = false;
		theDropZone.light.enabled = false;
		foreach (GameObject pickup in GameObject.FindGameObjectsWithTag("PickUpZone")) {
			pickup.renderer.enabled = true;
			pickup.light.enabled = true;
		}
		GameObject.Find ("LevelManager").SendMessage ("EndPickUp", SendMessageOptions.DontRequireReceiver);
	}

	void Update() {
		if (isInPickupMode) {
			arrow.transform.LookAt(theDropZone.transform, new Vector3(0,1,0));
			arrow.transform.Rotate(new Vector3(25, 0, 0));
		}
	}
}
