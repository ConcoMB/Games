using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class JumpGameControl : MonoBehaviour {

    public Transform platformPrefab;

    private Transform playerTrans;
    private float platformsSpawnedUpTo = 0.0f;
    private ArrayList platforms;
    private float nextPlatformCheck = 0.0f;
	private int theScore = 0;
	public float theTime = 15;
	private bool timeUp = false;
	public static bool lost = false;
	private GUIStyle style;
	private GUIStyle timeUpStyle;
	public Font font;
	private Queue<GameObject> platformPool = new Queue<GameObject>();
	private int spawned = 0;

	void Awake () {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        platforms = new ArrayList();
        SpawnPlatforms(25.0f);
	}

	void Start() {
		lost = false;
		style = new GUIStyle ();
		style.fontSize = 30;
		style.font = font;
		style.normal.textColor = Color.blue;
		timeUpStyle = new GUIStyle ();
		timeUpStyle.fontSize = 60;
		timeUpStyle.font = font;
		timeUpStyle.normal.textColor = Color.blue;
	}

	void Update () {
		if (lost) {
			return;
		}
		theTime -= Time.deltaTime;
		if (theTime < 0) {
			theTime = 0;
			timeUp = true;
			StartCoroutine(WaitForBackToBoard());
			return;
		}

        //Do we need to spawn new platforms yet? (we do this every X meters we climb)
        float playerHeight = playerTrans.position.y;
        if (playerHeight > nextPlatformCheck) {
            PlatformMaintenaince(); //Spawn new platforms
        }

        //Update camera position if the player has climbed and if the player is too low: Set gameover.
        float currentCameraHeight = transform.position.y;
        float newHeight = Mathf.Lerp(currentCameraHeight, playerHeight, Time.deltaTime * 10);

        if (playerTrans.position.y > currentCameraHeight)
        {
            transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
        }else{
            //Player is lower..maybe below the cameras view?
            if (playerHeight < (currentCameraHeight - 10)) {
				GameOver();
			}
        }
		if (playerHeight > theScore)
        {
			theScore = (int)playerHeight;
        }
	}

	void GameOver() {
		lost = true;
		StartCoroutine (WaitForBackToBoard ());
	}
		
		void PlatformMaintenaince()
    {
        nextPlatformCheck = playerTrans.position.y + 10;
        //Delete all platforms below us (save performance)
        for(int i = platforms.Count-1; i >= 0; i--)
        {
            Transform plat = (Transform)platforms[i];
            if (plat.position.y < (transform.position.y - 10))
            {
				platformPool.Enqueue(plat.gameObject);
                platforms.RemoveAt(i);
            }            
        }

        //Spawn new platforms, 25 units in advance
        SpawnPlatforms(nextPlatformCheck + 25);
    }


    void SpawnPlatforms(float upTo)
    {
        float spawnHeight = platformsSpawnedUpTo;
        while (spawnHeight <= upTo)
        {
            float x = Random.Range(-10.0f, 10.0f);
            Vector3 pos = new Vector3(x, spawnHeight, 12.0f);

			Transform plat;
			if(platformPool.Count == 0) {
            	plat = (Transform)Instantiate(platformPrefab, pos, Quaternion.identity);
				Debug.Log("SPAWN " + spawned++);
			} else {
				plat = platformPool.Dequeue().transform;
			}
            platforms.Add(plat);

            spawnHeight += Random.Range(1.6f, 3.5f);
        }
        platformsSpawnedUpTo = upTo;
    }

	void OnGUI() {
		if (timeUp) {
			GUI.Label (new Rect (Screen.width / 2 - 200, Screen.height / 2, 200, 100), 
			           "TIME UP!", 
			           timeUpStyle);
			return;
		}
		if (lost) {
			GUI.Label (new Rect (Screen.width / 2 - 200, Screen.height / 2, 200, 100), 
			           "Game over", 
			           timeUpStyle);
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