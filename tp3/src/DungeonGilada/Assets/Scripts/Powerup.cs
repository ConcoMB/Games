using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public int value = 1;
	public string type;
	public string rotateAxis;
	public float rotationAmount = 45;
	private Transform target;
	private Knight knight;

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
	}

	void  OnTriggerEnter ( Collider other){
		if(other.name == "Knight"){
			knight.SendMessage("Powerup" + type, value, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}
