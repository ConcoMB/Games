using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	
	public int rotationSpeed = 3;
	public int health = 30;
	public float attackRate = 4.0f;
	public int strength = 3;
	public int expPoints = 100;
	public AudioClip hitSound;
	public AudioClip dieSound;
	public AudioClip attackSound;
	
	private float counter = 0.0f;
	private Transform target;
	private GameObject knightObject;
	private Knight knight;
	private bool deadStart;
	private Status status;
	private int tauntCounter = 0;
	private bool attackAnim = false;
	private bool hitAnim = false;

	public enum Status{Idle, Attacking, Hit, Dead}
	
	void Start () {
		knightObject = GameObject.FindGameObjectWithTag ("Player");
		target = knightObject.transform;
		knight = knightObject.GetComponent<Knight> ();
		AnimationEvent attackEvent = new AnimationEvent();
		attackEvent.functionName = "SetIdle";
		attackEvent.time = animation.GetClip("attack1").length;
		animation.GetClip("attack1").AddEvent(attackEvent);
		AnimationEvent attackEvent2 = new AnimationEvent();
		attackEvent2.functionName = "SetIdle";
		attackEvent2.time = animation.GetClip("attack2").length;
		animation.GetClip("attack2").AddEvent(attackEvent2);
		AnimationEvent hitEvent = new AnimationEvent();
		hitEvent.functionName = "SetIdle";
		hitEvent.time = animation.GetClip("hit1").length;
		animation.GetClip("hit1").AddEvent(hitEvent);
		AnimationEvent hitEvent2 = new AnimationEvent();
		hitEvent2.functionName = "SetIdle";
		hitEvent2.time = animation.GetClip("hit2").length;
		animation.GetClip("hit2").AddEvent(hitEvent2);
	}
	
	void Update () {
		if (status != Status.Idle) {
			return;
		}
		float distance = Vector3.Distance (transform.position, target.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, 
		                                       Quaternion.LookRotation (target.position - transform.position), 
		                                       rotationSpeed * Time.deltaTime);
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		if (deadStart) {
			animation.Play ("death1");
			StartCoroutine(WaitForWin());
			status = Status.Dead;
		} else if (distance < 3) {
			counter += Time.deltaTime;
			if (counter > attackRate) {
				AudioSource.PlayClipAtPoint(attackSound, Camera.main.transform.position);

				status = Status.Attacking;
				attackAnim = !attackAnim;
				if (attackAnim) {
					animation.Play ("attack1");	
				} else {
					animation.Play ("attack2");
				}
				knight.SendMessage("Hit", strength, SendMessageOptions.DontRequireReceiver);
				counter = 0.0f;
			} else {
				tauntCounter += 1;
				if (tauntCounter > 10) {
					tauntCounter = 0;
					animation.Play ("taunt");
				} else {
					animation.Play ("idle");
				}
			}
		} else {
			animation.Play("idle");
		}
	}
	
	void Hit(int strenght) {
		if (status == Status.Dead) {
			return;
		}
		health -= strenght;
		Debug.Log (health);
		if (health < 0) {
			AudioSource.PlayClipAtPoint(dieSound, Camera.main.transform.position);
			deadStart = true;
			collider.enabled = false;
			knight.SendMessage("Experience", expPoints, SendMessageOptions.DontRequireReceiver);
		} else {
			hitAnim = !hitAnim;
			if (hitAnim) {
				StartCoroutine(delayHit(1));
			} else {
				StartCoroutine(delayHit(2));
			}
			status = Status.Hit;
		}
	}

	IEnumerator delayHit(int i) {
		yield return new WaitForSeconds(0.5f);
		animation.Play ("hit" + i);	
		AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
		yield return null;	
	}

	void SetIdle() {
		status = Status.Idle;
	}

	IEnumerator WaitForWin() {
		yield return new WaitForSeconds(3f);
		Application.LoadLevel("Won");
		yield return null;	
	}
}
