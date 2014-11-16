using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {

	public Knight knight;
	public int value = 1;
	public AudioClip pickupSound;
	
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		knight = go.GetComponent<Knight>();
	}

	void  OnTriggerEnter ( Collider other){
		if(other.name == "Knight"){
			AudioSource.PlayClipAtPoint (pickupSound, Camera.main.transform.position);
			knight.SendMessage("EarnGold", value, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}
