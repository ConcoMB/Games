using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject currentCell;
	public GameObject nextCell;

	public int rotationSpeed = 3;
	public int moveSpeed = 1;

	void Start () {
	
	}

	void Update () {
		if (nextCell == null) {
			return;
		}
		transform.rotation = Quaternion.Slerp (transform.rotation, 
		                                       Quaternion.LookRotation (nextCell.transform.position - transform.position), 
		                                       rotationSpeed * Time.deltaTime);
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		float distance = Vector3.Distance (transform.position, nextCell.transform.position);
		transform.rotation = new Quaternion (0, transform.rotation.y, 0, transform.rotation.w);

		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		if (distance < 0.1) {
				currentCell = nextCell;
				transform.position = currentCell.transform.position;
				nextCell = null;
		}
	}
}
