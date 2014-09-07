using UnityEngine;
using System.Collections;

[System.Serializable]
public class FontEx
{
	public Font font;
	public Font boxFont;
	public Font labelFont;
	public Font buttonFont;
	public int width;
	public static FontEx getFontEx(FontEx[] fonts)
	{
		FontEx rc = null;
		int w = Screen.width;
		int h = Screen.height;
		
		for(int i=0; i<fonts.Length; i++)
		{
			int x1 = fonts[i].width;
			if(w >= x1)
			{
				rc = fonts[i];
			}
		}
		
		return rc;
	}
				
}

public class ChangeGUISkin : MonoBehaviour 
{
	public GUISkin guiSkin0;
	public FontEx[] fonts;
	public void OnGUI()
	{
		changeGUISkins(guiSkin0);
		Destroy(gameObject);
	}
	void changeGUISkins(GUISkin gs)
	{
		if(gs)
		{
			FontEx font0 = FontEx.getFontEx(fonts);
			if(font0!=null)
			{
				gs.font = font0.font;
				gs.box.font = font0.boxFont;
				gs.label.font = font0.labelFont;
				gs.button.font = font0.buttonFont;
			}
		}
	}
}
