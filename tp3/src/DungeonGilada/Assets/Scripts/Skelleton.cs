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
		transform.rotation = Quaternion.Slerp (transform.rotation, 
		                                      Quaternion.LookRotation (target.position - transform.position), 
		                                      rotationSpeed * Time.deltaTime);
//		transform.position = transform.forward * moveSpeed * Time.deltaTime;
	}
}
