using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PauseState : BaseMenuState 
{
	public string restartSTR = "Restart level";
	public string resumeSTR = "Resume";
	public string mainMenuSTR = "Main Menu";
	public float regularTimeScale = 1f;
	public int levelSceneIndex = 0;
	//the skin
	
	//the background texture
	public Texture backgroundTexture;
	
	public override void Awake(){
		base.Awake();
		transform.position = startPos;
	}

	public void Update()
		
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			MenuStateManager.enterStateUsingName(	m_stateID);		
			Time.timeScale=0;
		}
	}
	void unapuseGame()
	{
		Time.timeScale = regularTimeScale;
	}
	public override void onGUI()
	{
		
		float offsetX = transform.position.x;
		float offsetY = transform.position.y;

			if(backgroundTexture)
			{
				GUI.DrawTexture( GUIHelper.screenRect(0,0,1,1),backgroundTexture);
			}
			GUI.skin = guiSkin0;
			//draw a button which will increase the graphics quality
			if(addButton(GUIHelper.screenRect (offsetX-0.15f,offsetY-.15f,.3f,.1f),
				restartSTR))		
			{
				MenuStateManager.enterStateUsingGameObject(null);			
				unapuseGame();
				//load the first level.
				Application.LoadLevel(Application.loadedLevel);
			}
			
			//draw a button that will decrease the graphics quality
			if(addButton(GUIHelper.screenRect (offsetX-0.15f,offsetY,.3f,.1f),
				resumeSTR))			
			{
				MenuStateManager.enterStateUsingGameObject(null);
				unapuseGame();
			}
			
			if(addButton(GUIHelper.screenRect (offsetX-0.15f,offsetY+.15f,.3f,.1f),
				mainMenuSTR))		
			{
				MenuStateManager.enterStateUsingGameObject(null);
				unapuseGame();
				//load the first level.
				Application.LoadLevel( levelSceneIndex );
			}
		
	}	
}
