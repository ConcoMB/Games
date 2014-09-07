using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//the graphics state will set the quality of graphics.
public class GraphicsState : BaseMenuState 
{

	public override void onGUI()
	{
		GUI.skin = guiSkin0;
		
		float offsetX = transform.position.x+ MenuConstants.OFFSET_X;
		float offsetY = transform.position.y +MenuConstants.OFFSET_Y;
		
		//draw the graphic box
		GUI.Box( GUIHelper.screenRect (offsetX+0.525f,offsetY,.4f,.45f), "Reuls");

		//display a lable of the graphics quality
		GUI.Label(GUIHelper.screenRect (offsetX+0.57f,offsetY+0.1f,.4f,.475f) ,"Graphics Quality: " +
			QualitySettings.GetQualityLevel());
		
		//draw a button which will increase the graphics quality
		if(addButton(GUIHelper.screenRect (offsetX+0.6f,offsetY+0.2f,.1f,.1f),"+"))		
		{
			QualitySettings.IncreaseLevel();
		}
		
		//draw a button that will decrease the graphics quality
		if(addButton(GUIHelper.screenRect (offsetX+0.75f,offsetY+0.2f,.1f,.1f),"-"))		
		{
			QualitySettings.DecreaseLevel();
		}
	}	
}
