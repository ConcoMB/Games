using UnityEngine;
using System.Collections;

public class MainMenue : MonoBehaviour {

//	public Texture2D mainMenuBG;
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(0,0, Screen.width, Screen.height), "Chilenian Dungeons");
//		Texture2D mainMenuBGa = (Texture2D)Resources.Load(mainMenuBG, typeof(Texture2D));
//		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), mainMenuBG);

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,100,20), "Start Game")) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,70,100,20), "Close Game")) {
			Application.LoadLevel(2);
		}
	}
}

