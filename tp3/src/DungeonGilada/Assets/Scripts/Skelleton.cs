using UnityEngine;
using System.Collections;

public class Skelleton : MonoBehaviour {

	public int moveSpeed = 3;
	public int rotationSpeed = 3;
	private Transform target;

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void Update () {
		float distance = Vector3.Distance (transform.position, target.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, 
                      Quaternion.LookRotation (target.position - transform.position), 
                      rotationSpeed * Time.deltaTime);
		if (distance < 2) {
			animation.Play ("attack");
		} else if (distance < 10) {
			animation.Play ("run");
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		} else {
			animation.Play("idle");
		}
	}
}
