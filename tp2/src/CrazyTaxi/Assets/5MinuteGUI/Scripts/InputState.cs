using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InputState : BaseMenuState  
{
	//a list of controls
	public string[] controls = {"Roll: WASD or arrow keys",
								"Space: Jump"};
	
	//the controls we will display in the label
	private string m_controls;
	public void Start()
	{
		//parse the controls
		m_controls="";
		for(int i=0; i<controls.Length; i++)
		{
			m_controls += controls[i] + "\n";
		}
	}
	public override void onGUI()
	{
		GUI.skin = guiSkin0;		
		
		float offsetX = transform.position.x+ MenuConstants.OFFSET_X;
		float offsetY = transform.position.y +MenuConstants.OFFSET_Y;
		
		//draw the box
		GUI.Box( GUIHelper.screenRect (offsetX+0.525f,offsetY,.4f,.45f), "Input Menu");
		
		
		//draw the label for controls
		GUI.Label( GUIHelper.screenRect (offsetX+0.535f,offsetY+0.1f,.45f,.4f),m_controls);

	}	
}
