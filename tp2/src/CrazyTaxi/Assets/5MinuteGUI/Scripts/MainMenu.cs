//#define GOT_PRIME31_GAMECENTER

using UnityEngine;
using System.Collections;

public class MainMenu: BaseMenuState 
{
	#region variables
	
	//the background texture
	public Texture backTexture;
	
	//the options menu gameObject
	public GameObject optionsGO;
	
	//the credit menu gameObject
	public GameObject creditsGO;
	
	//the level select gameObject
	public GameObject levelSelectGO;
	//the gui skin

	//do  you want to use the quit button.
	public bool useQuitButton = false;
	
	//do  you want to use the highscore button.
	public bool useHighscoreButton = false;
	
	
	public string menuMenuSTR = "Main Menu";
	public string startButtonSTR = "Start";
	
	//public string optionsSTR = "Options";
	public string creditsSTR = "Rules";
	public string quitSTR = "Quit";
	//public string highscoreSTR = "Highscore";
	public GUIStyle introTextGS;
	
#endregion
	
	void Start()
	{
		//lets show the cursor and unlock it (incase it was).
		Screen.lockCursor=false;
		Screen.showCursor=true;
		Time.timeScale=1;
		if(RuntimePlatform.IPhonePlayer==Application.platform)
		{
#if GOT_PRIME31_GAMECENTER
			if(GameCenterBinding.isGameCenterAvailable())
			{
				GameCenterBinding.authenticateLocalPlayer();
			}
#endif
		}
		m_on=true;
	}
	//deactivate this object and active the incoming one.
	void changeGameObject(GameObject go)
	{
		go.active = true;
		gameObject.active=false;
	}
	
	public override void onGUI()
	{
		float offsetX = transform.position.x+MenuConstants.OFFSET_X;
		float offsetY = transform.position.y+MenuConstants.OFFSET_Y;
		GUI.skin = guiSkin0;
	
		//draw out background texture
		if(backTexture)
		{
			GUI.DrawTexture( GUIHelper.screenRect (0,0,1f,1f),backTexture);
		}	

		//draw the menu box
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.45f,.89f), menuMenuSTR);
		
		
		//draw the button
		if(addButton (GUIHelper.screenRect (offsetX+.05f,offsetY+.275f,.35f,.1f), startButtonSTR))
		{
//			swapObjects(levelSelectGO);
			Application.LoadLevel("PlayScene");
		}

		
		//draw the option button
//		if(addButton(GUIHelper.screenRect (offsetX+.05f,offsetY+.4f,.35f,.1f), optionsSTR))
//		{
//			swapObjects(optionsGO);
//		}

		//draw the credits  button
		if(addButton(GUIHelper.screenRect (offsetX+.05f,offsetY+.525f,.35f,.1f), creditsSTR))
		{
			swapObjects(creditsGO);
		}				
	
//		if(useHighscoreButton)
//		{
//			if(addButton (GUIHelper.screenRect (offsetX+.05f,offsetY+0.65f,.35f,.1f), highscoreSTR))
//			{
//	
//				if(RuntimePlatform.IPhonePlayer==Application.platform)
//				{
//		#if GOT_PRIME31_GAMECENTER
//					GameCenterBinding.showLeaderboardWithTimeScope(GameCenterLeaderboardTimeScope.AllTime);
//		#endif
//				}
//			}		
//		}
		
		//draw the quit button
		if(useQuitButton)
		{
			if(addButton (GUIHelper.screenRect (offsetX+.05f,offsetY+.775f,.35f,.1f),quitSTR))
			{
				Application.Quit();
			}				
		}
	}
	

}