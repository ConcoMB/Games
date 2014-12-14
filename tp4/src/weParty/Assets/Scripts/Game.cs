using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	static public int HumanPosition;
	static public int OrcPosition;
	
	static public int HumanPoints;
	static public int OrcPoints;

	static public Player winner;

	public enum Player { ORC, HUMAN, NULL };

	void Start () {
		OrcPosition = 0;
		HumanPosition = 0;
		winner = Player.NULL;
		Application.LoadLevel ("Board");
	}

	public static void SetPoints(int points, Player player) {
		if (player == Player.HUMAN) {
			HumanPoints = points;
		}
		int r = Random.Range (0, 2);
		Debug.Log (r);
		int r2 = Random.Range (1, 10);
		if (r == 0) {
			winner = Player.HUMAN;
			OrcPoints = HumanPoints - r2;
			if (OrcPoints < 0) {
				OrcPoints = 0;
			}
		} else {
			winner = Player.ORC;
			OrcPoints = HumanPoints + r2;
		}
	}
}
