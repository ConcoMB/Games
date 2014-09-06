using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//the audio state will easily allow you to set the volume of the music.
public class AudioState : BaseMenuState 
{
	public float musicVolume = 100f;


	public void Start()
	{
		float vol = PlayerPrefs.GetFloat("AudioVolume",1);
		musicVolume = vol * 100f;
	}
	public override void onGUI()
	{
		GUI.skin = guiSkin0;
		
		
		float offsetX = transform.position.x+ MenuConstants.OFFSET_X;
		float offsetY = transform.position.y +MenuConstants.OFFSET_Y;
		
		
		//draw the menu.		
		GUI.Box( GUIHelper.screenRect (offsetX+0.525f,offsetY,.4f,.45f), "Audio Menu");
		
		//draw the slider
		musicVolume = GUIHelper.sliderHelper(offsetX+.575f,offsetY+0.1f,.25f,.1f,
			"Volume: ",ref musicVolume,0,100);
		float vol = musicVolume * 0.01f;
		PlayerPrefs.SetFloat("AudioVolume",vol);
	}


}
