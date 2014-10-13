using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public GameObject spawnRoom;
	public Transform[] rooms;

	// Use this for initialization
	void Start () {
		GameObject mountPoint = spawnRoom.transform.FindChild("Mount Point").gameObject;
		for (int i = 0; i < 5; i++) {
			bool collission = false;
			int index = Random.Range(0, rooms.Length);
			do {
				Transform room = (Transform) Instantiate(rooms[index], mountPoint.transform.position, mountPoint.transform.rotation);
				GameObject newMountPoint = room.FindChild("Mount Point").gameObject;
				if (Physics.Raycast(newMountPoint.transform.position, newMountPoint.transform.TransformDirection(Vector3.forward), 2)) {
					Debug.Log ("hit");
					collission = true;
					index = (index + 1) % rooms.Length;
					Destroy (room.gameObject);
				}else{
					mountPoint = newMountPoint;
					collission = false;
				}
			} while(collission);
		}
	}
}
