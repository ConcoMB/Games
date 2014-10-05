using UnityEngine;
using System.Collections;

public class stars : MonoBehaviour {

	public float startSpeed = 12;
	private int level = 1;

	void Start() {
		GameObject enemyspawner = GameObject.Find ("enemyspawner");
		SetupSpeed ();
	}

	void SetupSpeed() {
		particleSystem.startSpeed = Random.Range (startSpeed * level, startSpeed * level * 1.5f);
	}

	void  levelup ( int lvlNumber  ){
		level = lvlNumber;
		SetupSpeed ();
	}
}
