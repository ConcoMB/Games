using UnityEngine;
using System.Collections;

public class PointsManager : MonoBehaviour {

	public int points = 0;
	public GameObject pickupManager;
	private PickUpManager pickupManagerScript;

	void Start() {
		pickupManagerScript = pickupManager.GetComponent<PickUpManager>();
	}

	void NotifyPoints(int morePoints) {
		if (IsInPickupMode()) {
			if (morePoints < 0) {
				morePoints = -1 * morePoints;
			}
			points += morePoints;
		}
	}

	bool IsInPickupMode() {
		return pickupManagerScript.isInPickupMode;
	}

	void NotifyReset() {
		points = points / 2;
	}
}
