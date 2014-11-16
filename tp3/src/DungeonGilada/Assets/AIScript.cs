using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {
	
	public int theScore = 0;
	
	void Update () {
		float moveInput = Input.GetAxis("Horizontal") * Time.deltaTime * 3; 
		transform.position += new Vector3(moveInput, 0, 0);
		if (transform.position.x <= -2.5f || transform.position.x >= 2.5f)
		{
			float xPos = Mathf.Clamp(transform.position.x, -2.5f, 2.5f);
			transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
		}
	}
	
	void OnGUI()
	{
		GUILayout.Label("Score: " + theScore);
	}    
}
