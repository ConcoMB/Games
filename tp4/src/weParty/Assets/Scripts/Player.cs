using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject currentCell;
	public GameObject nextCell;
	public GameObject finalCell;
	public GameObject cellManagerGO;
	private DataManager dataManager;

	public int rotationSpeed = 3;
	public int moveSpeed = 1;

	void Start () {
		finalCell = GameObject.FindGameObjectWithTag ("LastCell");
		dataManager = cellManagerGO.GetComponent<DataManager> ();
	}

	void Update () {
		if (nextCell == null) {
			return;
		}
		transform.rotation = Quaternion.Slerp (transform.rotation, 
		                                       Quaternion.LookRotation (nextCell.transform.position - transform.position), 
		                                       0.1f
		                                       );
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		float distance = Vector3.Distance (transform.position, nextCell.transform.position);
		transform.rotation = new Quaternion (0, transform.rotation.y, 0, transform.rotation.w);

		transform.position += transform.forward * moveSpeed * Time.deltaTime;
		if (distance < 0.5) {
			currentCell = nextCell;
			transform.position = currentCell.transform.position;
			Debug.Log(currentCell == finalCell);
			if (currentCell == finalCell) {
				dataManager.SendMessage ("Win", SendMessageOptions.DontRequireReceiver);
				return;
			}
			dataManager.SendMessage ("FinishedMoving", SendMessageOptions.DontRequireReceiver);
			nextCell = null;
		}
	}
}
