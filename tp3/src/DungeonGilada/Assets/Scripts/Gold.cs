using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {

	public Knight knight;
	public int value = 1;
	private Transform target;
	
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
		knight = go.GetComponent<Knight>();
	}
	
	void Update () {
		float distance = Vector3.Distance (transform.position, target.position);
		if (distance < 0.5) {
			knight.SendMessage("EarnGold", value, SendMessageOptions.DontRequireReceiver);
			renderer.enabled = false;
			light.enabled = false;
			Destroy(this);
		}
	}
}
