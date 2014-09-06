using UnityEngine;
using System.Collections;

public class GUIHelper   : MonoBehaviour {
	public static Rect screenRect(Rect r) 
	{
		return screenRect(r.x,r.y,r.width,r.height);
	}
	public static void drawHealthBar(Rect r0,
												float val,
												Texture t0,
												Texture t1)
	{
		
		Rect r = r0;
		if(t0!=null && t1 !=null)
		{
			float a = r0.width * val;
			float b = r0.width - a;

			r.x 		+= a;
			r.width   = b;
			GUI.DrawTexture( r,t0 );			
			
			if(a > 0)
			{
				r.x = r0.x;
				r.width = a;
				GUI.DrawTexture(r,t1);
			}
		}
	}
	//takes in normalized screen cordinates (0..1) and returns the actual rect using the screen width and height
	public static Rect screenRect(float left,
								  float top,
								   float width,
								 float height) 
	{
		float x1 = left * Screen.width;
		float y1 = top * Screen.height;
		
		float sw = width * Screen.width;
		float sh = height * Screen.height;
		
		
		return new Rect(x1,y1,sw,sh);
	}
	public static void drawHealthbar(Rect screeRect0,
							  Texture t0,
							   Texture t1,
							   float val)
	{
		Rect tmpRect = screeRect0;
		val = 1.0f - val;
		//tmpRect = screenRect;
		float width = tmpRect.height;
		float invVal = 1.0f - val;
		
		float h0 = val * width;
		tmpRect.height = h0;
		
		if(t0 && t1)
		{
			if(val > 0)
			{
				GUI.DrawTexture( tmpRect,t0);
			}
			
			tmpRect.y = tmpRect.y + h0;
			tmpRect.height = invVal * width;
			
			if(invVal > 0)
			{
				GUI.DrawTexture( tmpRect, t1); 
			}
		}
	}
	
	//draw our little slider helper -- that is a label and slider.
	public static float sliderHelper(float left, float top, float width, float height,
								  string labelString,
								   ref float val,
									float minVal,
									float maxVal)
	{
		int iVal = (int)val;
		GUI.Label (GUIHelper.screenRect (left,top-0.05f,width,height) ,labelString + iVal + " %");
		val = GUI.HorizontalSlider (GUIHelper.screenRect (left,top,width,height), val, minVal, maxVal);
		return val;
	}
}
