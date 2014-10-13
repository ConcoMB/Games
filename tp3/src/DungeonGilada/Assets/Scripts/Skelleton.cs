using UnityEngine;
using System.Collections;

public class Skelleton : MonoBehaviour {

	public int moveSpeed = 3;
	public int rotationSpeed = 3;
	public int health = 2;
	private Transform target;
	private bool deadStart;
	private Status status;

	public enum Status{Idle, Attacking, Hit, Dead}

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		AnimationEvent e = new AnimationEvent();
		e.functionName = "SetNoMoreHit";
		e.time = animation.GetClip("gethit").length;
		animation.GetClip("gethit").AddEvent(e);
	}
	
	void Update () {
		if (status == Status.Dead || status == Status.Hit) {
			return;
		}
		float distance = Vector3.Distance (transform.position, target.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, 
		      Quaternion.LookRotation (target.position - transform.position), 
		      rotationSpeed * Time.deltaTime);
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		if (deadStart) {
			animation.Play ("die");
			status = Status.Dead;
		} else if (distance < 3) {
			animation.Play ("attack");
		} else if (distance < 10) {
			animation.Play ("run");
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		} else {
			animation.Play("idle");
		}
	}

	void Hit(int strenght) {
		Debug.Log (health);
		health -= strenght;
		if (health < 0) {
			deadStart = true;
		} else {
			animation.Play ("gethit");
			status = Status.Hit;
		}
	}

	void SetNoMoreHit() {
		status = Status.Idle;
	}
}
