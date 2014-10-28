using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public GameObject spawnRoom;
	public Transform finalRoom;
	public Transform[] rooms;
	public int length = 5;

	// Use this for initialization
	void Start () {
		GameObject mountPoint = spawnRoom.transform.FindChild("Mount Point").gameObject;
		for (int i = 0; i < length - 1; i++) {
			bool collission = false;
			int index = Random.Range(0, rooms.Length);
			int tries = 0;
			do {
				Transform room = (Transform) Instantiate(rooms[index], mountPoint.transform.position, mountPoint.transform.rotation);
				GameObject newMountPoint = room.FindChild("Mount Point").gameObject;
				if (Physics.Raycast(newMountPoint.transform.position, newMountPoint.transform.TransformDirection(Vector3.forward), 3)) {
					Debug.Log ("hit");
					collission = true;
					index = (index + 1) % rooms.Length;
					Destroy (room.gameObject);
					tries++;
					if(tries >= rooms.Length) {
						Debug.Log ("Premature final room");
						addFinalRoom(mountPoint);
						return;
					}
				}else{					
					mountPoint = newMountPoint;
					collission = false;
				}
			} while(collission);

		}
		addFinalRoom (mountPoint);
	}

	private void addFinalRoom(GameObject mountPoint) {
		Transform finalRoomT = (Transform) Instantiate(finalRoom, mountPoint.transform.position, mountPoint.transform.rotation);
	}
}
