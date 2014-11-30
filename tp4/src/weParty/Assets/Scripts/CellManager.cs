using UnityEngine;
using System.Collections;

public class CellManager : MonoBehaviour {

	public GameObject[] cells;
	public GameObject orcGO;
	public GameObject humanGO;
	private Player human;
	private Player orc;
	public Status status;
	private int moves;
	public GUIStyle style;
	public Font font;
	public enum Status { MOVING, PICK_GAME, GAME_PICKED, WIN }
	public string[] games = { "EggCatch", "Jump" };
	public string game;

	void Start () {
		style = new GUIStyle ();
		style.fontSize = 60;
		style.font = font;
		style.normal.textColor = Color.white;
		if (status == Status.WIN) {
			return;
		}
		Debug.Log (Game.OrcPosition);
		orcGO.transform.position = cells [Game.OrcPosition].transform.position;
		humanGO.transform.position = cells [Game.HumanPosition].transform.position;
		human = humanGO.GetComponent<Player> ();
		human.currentCell = cells [Game.HumanPosition];
		orc = humanGO.GetComponent<Player> ();
		human.currentCell = cells [Game.HumanPosition];
		orc.currentCell = cells [Game.OrcPosition];
		moves = Random.Range (1, 4);
		status = Status.MOVING;
		switch (Game.winner) {
		case Game.Winner.HUMAN:
			Game.HumanPosition += moves;
			if (Game.HumanPosition >= cells.Length) {
				Game.HumanPosition = cells.Length - 1;
			}
			human.nextCell = cells [Game.HumanPosition];
			break;
		case Game.Winner.ORC:
			Game.OrcPosition = (Game.OrcPosition + moves) % cells.Length;
			if (Game.OrcPosition >= cells.Length) {
				Game.OrcPosition = cells.Length - 1;
			}
			orc.nextCell = cells [Game.OrcPosition];
			break;
		}
	}

	void Update() {
		if (status != Status.PICK_GAME) {
			return;
		}
		int r = Random.Range (0, games.Length - 1);
		game = games[r];
		StartCoroutine(waitToSetStatus(Status.GAME_PICKED));
		StartCoroutine(WaitToPlayGame());
	}

	void OnGUI(){
		switch (status) {
		case Status.MOVING:
			GUI.Label (new Rect (Screen.width / 2 - 300, 100, 200, 100), 
			           (Game.winner == Game.Winner.HUMAN ? "Human" : "Orc") + " moves " + moves + " cells", 
			           style);
			break;
		case Status.PICK_GAME:
			GUI.Label (new Rect (Screen.width / 2 - 200, 100, 200, 100), 
			           "Time to play!", 
			           style);
			break;
		case Status.GAME_PICKED:
			GUI.Label (new Rect (Screen.width / 2 - 400, 100, 200, 100), 
			           "Game to play: " + game, 
			           style);
			break;
		case Status.WIN:
			GUI.Label (new Rect (Screen.width / 2 - 300, 100, 200, 100), 
			           (Game.winner == Game.Winner.HUMAN ? "Human" : "Orc") + "wins", 
			           style);
			break;
		}
	}

	void Win() {
		status = Status.WIN;
	}

	void FinishedMoving() {
		StartCoroutine(waitToSetStatus(Status.PICK_GAME));
	}

	IEnumerator WaitToPlayGame() {
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel (game);
	}

	IEnumerator waitToSetStatus(Status st) {
		yield return new WaitForSeconds(2.0f);
		status = st;
	}
}
