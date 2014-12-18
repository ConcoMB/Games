using UnityEngine;
using System.Collections;

public class EggPlayerScript : MonoBehaviour {
    
    public int theScore = 0;
	public float theTime = 15;
	private GUIStyle style;
	private GUIStyle timeUpStyle;
	public Font font;
	private bool timeUp;

	void Start() {
		style = new GUIStyle ();
		style.fontSize = 30;
		style.font = font;
		style.normal.textColor = Color.white;
		timeUpStyle = new GUIStyle ();
		timeUpStyle.fontSize = 60;
		timeUpStyle.font = font;
		timeUpStyle.normal.textColor = Color.white;
	}

	void Update () {
		theTime -= Time.deltaTime;
		if (theTime < 0) {
			theTime = 0;
			timeUp = true;
			StartCoroutine(WaitForBackToBoard());
			return;
		}
        float moveInput = Input.GetAxis("Horizontal") * Time.deltaTime * 3;
		if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];
			if (touch.position.x < Screen.width/2)
			{
				moveInput = - Time.deltaTime * 3;
			}
			else if (touch.position.x > Screen.width/2)
			{
				moveInput = Time.deltaTime * 3;
			}
		}

        transform.position += new Vector3(moveInput, 0, 0);

        if (transform.position.x <= -2.5f || transform.position.x >= 2.5f)
        {
            float xPos = Mathf.Clamp(transform.position.x, -2.5f, 2.5f); 
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
	}

    void OnGUI()
    {
		if (timeUp) {
			GUI.Label (new Rect (Screen.width / 2 - 200, Screen.height / 2, 200, 100), 
			           "TIME UP!", 
			           timeUpStyle);
			return;
		}
		GUI.Label (new Rect (50, 50, 200, 100), 
		          "Score: " + theScore, 
		          style);
		GUI.Label (new Rect (50, 100, 200, 100), 
		           "Time left: " + (int) theTime, 
		           style);
    }    

	IEnumerator WaitForBackToBoard() {
		Game.SetPoints (theScore, Game.Player.HUMAN);
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel ("Results");
	}
}
