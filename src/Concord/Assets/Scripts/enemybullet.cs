using UnityEngine;
using System.Collections;

public class enemybullet : MonoBehaviour {
	
	public float bulletSpeed = 24.0f;	

	private GameObject target;
	private float lifeCounter = 0.0f;
	
	void  Start (){
		target = GameObject.Find("player");
		if (target == null) {
			return;
		}
		Vector3 dir = target.transform.position - transform.position;
		dir = dir.normalized;
		rigidbody.AddForce(dir * 350);
	}
	
	void  Update () {
		lifeCounter += Time.deltaTime;
		if (transform.position.x < -12) {
			Destroy(gameObject);
		}
		if (lifeCounter > 6) {
			Destroy(gameObject);
		}
	}
}