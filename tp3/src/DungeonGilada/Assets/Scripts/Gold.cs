using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {

	public PlayerDataManager manager;
	public int value = 1;
	private Transform target;
	
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void Update () {
		float distance = Vector3.Distance (transform.position, target.position);
		Debug.Log ("gold: " + distance);
		if (distance < 0.5) {
			manager.SendMessage("EarnGold", value, SendMessageOptions.DontRequireReceiver);
			renderer.enabled = false;
			light.enabled = false;
			Destroy(this);
		}
	}
}
