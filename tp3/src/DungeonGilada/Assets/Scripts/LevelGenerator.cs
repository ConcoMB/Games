using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public GameObject spawnRoom;
	public Transform[] rooms;

	// Use this for initialization
	void Start () {
		GameObject mountPoint = spawnRoom.transform.FindChild("Mount Point").gameObject;
		for (int i = 0; i < 5; i++) {
			int index = Random.Range(0, rooms.Length - 1);
			Debug.Log (index);
			Transform room = (Transform) Instantiate(rooms[index], mountPoint.transform.position, mountPoint.transform.rotation);
			mountPoint = room.FindChild("Mount Point").gameObject;
		}
	}
}
