using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public int value = 1;
	public string type;
	public string rotateAxis;
	public float rotationAmount = 45;
	private Knight knight;
	public AudioClip pickupSound;

	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
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
			AudioSource.PlayClipAtPoint (pickupSound, Camera.main.transform.position);
			knight.SendMessage("Powerup" + type, value, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}
