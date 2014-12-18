using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour {

	public GameObject[] cells;
	public GameObject orcGO;
	public GameObject humanGO;
	private Player human;
	private Player orc;
	public Status status;
	private int moves;
	private GUIStyle style;
	private GUIStyle buttonStyle;
	public Font font;
	public enum Status { MOVING, MOVED, PICK_GAME, GAME_PICKED, WIN }
	public string[] games = { "EggCatch", "Jump" };
	public string game;

	void Start () {
		style = new GUIStyle ();
		style.fontSize = 60;
		style.font = font;
		style.normal.textColor = Color.white;
		buttonStyle = new GUIStyle ();
		buttonStyle.fontSize = 60;
		buttonStyle.font = font;
		buttonStyle.normal.textColor = Color.yellow;
		if (status == Status.WIN) {
			return;
		}
		orcGO.transform.position = cells [Game.OrcPosition].transform.position;
		humanGO.transform.position = cells [Game.HumanPosition].transform.position;
		human = humanGO.GetComponent<Player> ();
		human.currentCell = cells [Game.HumanPosition];
		orc = orcGO.GetComponent<Player> ();
		human.currentCell = cells [Game.HumanPosition];
		orc.currentCell = cells [Game.OrcPosition];
		moves = Random.Range (1, 4);
		status = Status.MOVING;
		switch (Game.winner) {
		case Game.Player.HUMAN:
			Game.HumanPosition += moves;
			if (Game.HumanPosition >= cells.Length) {
				Game.HumanPosition = cells.Length - 1;
			}
			human.nextCell = cells [Game.HumanPosition];
			break;
		case Game.Player.ORC:
			Game.OrcPosition += moves;
			if (Game.OrcPosition >= cells.Length) {
				Game.OrcPosition = cells.Length - 1;
			}
			orc.nextCell = cells [Game.OrcPosition];
			break;
		case Game.Player.NULL:
			status = Status.PICK_GAME;
			break;
		}
	}

	void Update() {
		if (status != Status.PICK_GAME) {
			return;
		}
		int r = Random.Range (0, 100);
		game = games[r % games.Length];
//		StartCoroutine(waitToSetStatus(Status.GAME_PICKED));

		status = Status.GAME_PICKED;
		StartCoroutine(WaitToPlayGame());
	}

	void OnGUI(){
		switch (status) {
		case Status.MOVING:
			GUI.Label (new Rect (Screen.width / 2 - 350, 100, 200, 100), 
			           (Game.winner == Game.Player.HUMAN ? "Human" : "Orc") + " moves " + moves + " cells", 
			           style);
			break;
		case Status.PICK_GAME:
			GUI.Label (new Rect (Screen.width / 2 - 200, 100, 200, 100), 
			           "Time to play!", 
			           style);
			break;
		case Status.MOVED:
			if(GUI.Button(new Rect(Screen.width / 2 - 300, 100, 600, 200), 
			              "PLAY NEXT ROUND", 
			              buttonStyle)){
				status = Status.PICK_GAME;
			}
			break;
		case Status.GAME_PICKED:
			GUI.Label (new Rect (Screen.width / 2 - 400, 100, 200, 100), 
			           "Game to play: " + game, 
			           style);
			break;
		case Status.WIN:
			GUI.Label (new Rect (Screen.width / 2 - 200, 100, 200, 100), 
			           (Game.winner == Game.Player.HUMAN ? "Human" : "Orc") + " wins!!", 
			           style);
			break;
		}
	}

	void Win() {
		status = Status.WIN;
		StartCoroutine(WaitToWin());
	}

	void FinishedMoving() {
		StartCoroutine(waitToSetStatus(Status.MOVED));
	}

	IEnumerator WaitToWin() {
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel ("Won");
	}

	IEnumerator WaitToPlayGame() {
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel (game);
	}

	IEnumerator waitToSetStatus(Status st) {
		yield return new WaitForSeconds(3.0f);
		status = st;
	}
}
