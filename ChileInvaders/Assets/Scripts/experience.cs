using UnityEngine;
using System.Collections;

public class experience : MonoBehaviour {

	private GameObject target;
	
	void  Start (){
		target = GameObject.Find("player");
		rigidbody.velocity = new Vector3(Random.Range(-4,4),0,Random.Range(-4,4));
	}
	
	void Update(){
		if (target == null) {
				return;
		}
		Vector3 dir = target.transform.position - transform.position;
		dir = dir.normalized;
		rigidbody.AddForce(dir * 1000 * Time.deltaTime);
	}
}