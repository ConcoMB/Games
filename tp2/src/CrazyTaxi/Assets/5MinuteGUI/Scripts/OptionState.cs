using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//the option state
public class OptionState : BaseMenuState 
{
	#region variables
	//our background texture
	public Texture backTexture;
	
	public string graphicsSTR = "Graphics";
	public string audioSTR = "Audio";
	public string inputSTR = "Input";
	
	//the graphics menu gameobject
	public GameObject graphicsGO;
	
	//the audi menu gameobject
	public GameObject audioGO;
	
	//the input menu gameobject
	public GameObject inputGO;
	
	//the main menu gameObject
	public GameObject mainMenuGO;
		
	//the skin
	
	//our private currently selected gameObject
	private GameObject m_currentSelectedGO;
	
	#endregion

	void swapGameObject(GameObject go)
	{
		if(go!=m_currentSelectedGO)
		{
			if(m_currentSelectedGO && m_currentSelectedGO!=go)
			{
				m_currentSelectedGO.SendMessage("disable",-1);
			}
			if(go)
			{
				go.SendMessage("enable");
			}
		}
		m_currentSelectedGO = go;		
		
	}
	public override void onGUI()
	{
		float offsetX = transform.position.x + MenuConstants.OFFSET_X;
		float offsetY = transform.position.y + MenuConstants.OFFSET_Y;
		GUI.skin = guiSkin0;
		
		//draw out background texture
		if(backTexture)
		{
			GUI.DrawTexture( GUIHelper.screenRect (0,0,1f,1f),backTexture);
		}	
		
	
		//draw out box		
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.45f,.89f), "Option Menu");
		
		//draw the graphics button
		if(addButton (GUIHelper.screenRect (offsetX+.05f,offsetY+.2f,.35f,.1f), graphicsSTR))
		{
			swapGameObject(graphicsGO);
		}
		
		//draw the audio button
		if(addButton (GUIHelper.screenRect (offsetX+.05f,offsetY+.325f,.35f,.1f), audioSTR))
		{
			swapGameObject(audioGO);
		}		
		
		//draw the input button
		if(addButton (GUIHelper.screenRect (offsetX+.05f,offsetY+.45f,.35f,.1f), inputSTR))
		{
			swapGameObject(inputGO);
		}		
		
		
		//draw the main menu button
		if(addButton(GUIHelper.screenRect (offsetX+.05f,offsetY+.775f,.35f,.1f), "Main Menu"))
		{
			if(m_currentSelectedGO)
			{
				m_currentSelectedGO.SendMessage("disable",-1);
			}
			swapObjects(mainMenuGO);
		}
	}
}
