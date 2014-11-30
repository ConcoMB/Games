using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	static public int HumanPosition;
	static public int OrcPosition;
	static public Player winner;

	public enum Player { ORC, HUMAN, NULL };

	void Start () {
		OrcPosition = 0;
		HumanPosition = 0;
		winner = Player.NULL;
		Application.LoadLevel ("Board");
	}

	public static void SetPoints(int points, Player player) {
		int r = Random.Range (0, 1);
		Debug.Log (r);
		if (r == 0) {
			winner = Player.HUMAN;
		} else {
			winner = Player.ORC;
		}
	}
}
