using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public Knight knight;
	public int value = 1;
	public string type;
	public string rotateAxis;
	public float rotationAmount = 45;
	private Transform target;
	
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
		knight = go.GetComponent<Knight>();
	}
	
	void Update () {
		switch (rotateAxis) {
		case "x" :
			transform.Rotate (rotationAmount * Time.deltaTime, 0, 0);
			break;
		case "y":
			transform.Rotate (0, rotationAmount * Time.deltaTime, 0);
			break;
		case "z":
			transform.Rotate (0, 0, rotationAmount * Time.deltaTime);
			break;
		}
		float distance = Vector3.Distance (transform.position, target.position);
		if (distance < 1) {
			knight.SendMessage("Powerup" + type, value, SendMessageOptions.DontRequireReceiver);
			renderer.enabled = false;
			light.enabled = false;
			Destroy(this);
		}
	}
}
