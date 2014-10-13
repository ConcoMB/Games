using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public int health = 10;
	public int strength = 1;
	public int armor = 0;
	public Status status = Status.Idle;

	public enum Status{Idle, Attacking, Defending};
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
