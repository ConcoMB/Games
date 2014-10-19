using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	private Knight knight;
	public GameObject knightObj;

	void Start () {
		knight = (Knight) knightObj.GetComponent<Knight>();
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Debug.Log (other.tag);
		if (other.tag == "enemy" && knight.status == Knight.Status.Attacking) {
			other.SendMessage("Hit", knight.strength, SendMessageOptions.DontRequireReceiver);
		}
	}
}
