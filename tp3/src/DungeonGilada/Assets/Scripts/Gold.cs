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

	void  OnTriggerEnter ( Collider other){
		if(other.name == "Knight"){
			knight.SendMessage("EarnGold", value, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}
