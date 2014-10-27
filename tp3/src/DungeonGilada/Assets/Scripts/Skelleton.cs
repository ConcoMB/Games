using UnityEngine;
using System.Collections;

public class Skelleton : MonoBehaviour {

	public int moveSpeed = 3;
	public AudioClip dieSound;
	public AudioClip laughSound;
	public AudioClip attackSound;
	public AudioClip hitSound;

	public int rotationSpeed = 3;
	public int health = 10;
	public float attackRate = 4.0f;
	public int strength = 1;
	public int expPoints = 1;

	private float counter = 0.0f;
	private Transform target;
	private GameObject knightObject;
	private Knight knight;
	private bool deadStart;
	private Status status;
	private bool laughed = false;

	public enum Status{Idle, Attacking, Hit, Dead}

	void Start () {
		knightObject = GameObject.FindGameObjectWithTag ("Player");
		if (knightObject != null) {
			target = knightObject.transform;
			knight = knightObject.GetComponent<Knight> ();
		}
		AnimationEvent hitEvent = new AnimationEvent();
		hitEvent.functionName = "SetIdle";
		hitEvent.time = animation.GetClip("gethit").length;
		animation.GetClip("gethit").AddEvent(hitEvent);
		AnimationEvent attackEvent = new AnimationEvent();
		attackEvent.functionName = "SetIdle";
		attackEvent.time = animation.GetClip("attack").length;
		animation.GetClip("attack").AddEvent(attackEvent);
	}
	
	void Update () {
		if (status != Status.Idle || knight == null) {
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
			counter += Time.deltaTime;
			if (counter > attackRate) {
				AudioSource.PlayClipAtPoint(attackSound, Camera.main.transform.position);

				status = Status.Attacking;
				animation.Play ("attack");	
				knight.SendMessage("Hit", strength, SendMessageOptions.DontRequireReceiver);
				counter = 0.0f;
			} else {
				animation.Play ("waitingforbattle");		
			}
		} else if (distance < 10) {
			if (!laughed) {
				laughed = true;
				AudioSource.PlayClipAtPoint(laughSound, Camera.main.transform.position);
			}

			animation.Play ("run");
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		} else {
			animation.Play("idle");
		}
	}

	void Hit(int strenght) {
		if (status == Status.Dead) {
			return;
		}
		Debug.Log (health);
		health -= strenght;
		if (health < 0) {
			AudioSource.PlayClipAtPoint(dieSound, Camera.main.transform.position);
			deadStart = true;
			collider.enabled = false;
			knight.SendMessage("Experience", expPoints, SendMessageOptions.DontRequireReceiver);
			status = Status.Idle;
		} else {
			AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
			animation.Play ("gethit");
			status = Status.Hit;
		}
	}

	void SetIdle() {
		status = Status.Idle;
	}
}
