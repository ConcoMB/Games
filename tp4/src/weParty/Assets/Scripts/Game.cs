using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	static public int HumanPosition;
	static public int OrcPosition;
	static public Winner winner;

	public enum Winner { ORC, HUMAN };

	void Start () {
		OrcPosition = 3;
		HumanPosition = 5;
		winner = Winner.HUMAN;
		Application.LoadLevel ("Board");
	}
}
