using UnityEngine;
using System.Collections;

public class FantasyKnight : MonoBehaviour {

	public enum Status{Idle, Attacking, Hit, Dead}

	void Start () {
		animation.Play ("idle");
	}
	
	void Update () {
		bool leftMouseClick = Input.GetMouseButtonDown(0);
//		if (leftMouseClick) {
//			animation.Play ("attack01");
//		}

	}
}
