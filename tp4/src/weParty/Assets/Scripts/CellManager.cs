using UnityEngine;
using System.Collections;

public class CellManager : MonoBehaviour {

	public GameObject[] cells;
	public GameObject orcGO;
	public GameObject humanGO;
	private Player human;
	private Player orc;

	void Start () {
		orcGO.transform.position = cells [Game.OrcPosition].transform.position;
		humanGO.transform.position = cells [Game.HumanPosition].transform.position;
		human = humanGO.GetComponent<Player> ();
		human.currentCell = cells [Game.HumanPosition];
		orc = humanGO.GetComponent<Player> ();
		human.currentCell = cells [Game.HumanPosition];
		orc.currentCell = cells [Game.OrcPosition];
		int r = Random.Range (1, 4);
		Debug.Log (r);
		switch (Game.winner) {
		case Game.Winner.HUMAN:
			Game.HumanPosition = (Game.HumanPosition + r) % cells.Length;
			human.nextCell = cells [Game.HumanPosition];
			break;
		case Game.Winner.ORC:
			Game.OrcPosition = (Game.OrcPosition + r) % cells.Length;
			orc.nextCell = cells [Game.OrcPosition];
			break;
		}
	}
}
