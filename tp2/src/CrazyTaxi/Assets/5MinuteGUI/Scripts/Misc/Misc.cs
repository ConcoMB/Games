using UnityEngine;
using System.Collections;

public class Misc : MonoBehaviour {
	public static string MAX_LEVEL_STR = "XXX_MAXX_LEVEL";

	public static float MOBILE_SPAWN_DELAY_TIME_SCALAR  = 2f;
	public static float MOBILE_ASTEROID_MOVE_SCALAR = 0.5f;
		
	
	public static string START_ROUND_STR = "XX_START_ROUND";
	public static string START_SPAWNER_STR = "XX_START_SPAWNER";
	
	public static void setStartSpawnerIndex(int startRound)
	{
		PlayerPrefs.SetInt(START_SPAWNER_STR,startRound);
	}
	
	public static int getStartSpawnerIndex()
	{
		return PlayerPrefs.GetInt(START_SPAWNER_STR,0);
	}
	
	
	public static void setStartRound(int startRound)
	{
		PlayerPrefs.SetInt(START_ROUND_STR,startRound);
	}
	
	public static int getStartRound()
	{
		return PlayerPrefs.GetInt(START_ROUND_STR,1);
	}
	
	public static void setChildrenActive(GameObject go,
											bool active)
	{
		Transform t0 = go.transform;
		int t= t0.GetChildCount();
		for(int i=0; i<t; i++)
		{
			if(t0.gameObject!=go)
			{
				t0.gameObject.active = active;
			}
		}
	}
	public static void setActiveRecursively(GameObject go,
											bool active)
	{
		Transform t0 = go.transform;
		int t= t0.GetChildCount();
		for(int i=0; i<t; i++)
		{
			t0.gameObject.active = active;
		}
	}
	
	
	
	public static bool setMaxLevel(int maxLevel)
	{
		bool newMaxLevel = false;
		int curMax = getMaxLevel();
		if(maxLevel > curMax)
		{
			PlayerPrefs.SetInt(MAX_LEVEL_STR,maxLevel);
			newMaxLevel = true;
		}
		return newMaxLevel;
	}
	
	public static int getMaxLevel()
	{
		return PlayerPrefs.GetInt(MAX_LEVEL_STR,2);
	}
	public static bool isMobilePlatform()
	{
		return RuntimePlatform.IPhonePlayer==Application.platform || Application.platform==RuntimePlatform.Android;
	}
	public static void createAndDestroyGameObject (GameObject effectGO,
													Vector3 pos,
													float effectTTL) 
	{
		if(effectGO)
		{
			GameObject g0 = (GameObject)Instantiate( effectGO,pos,Quaternion.identity);
			if(g0)
			{
				Destroy(g0,effectTTL);
			}
		}
	
	}
	public static Component getComponentInChildrenNotSelf(Transform t1, string scriptName)
	{
		Component rc = null;
		for(int i=0; i<t1.GetChildCount(); i++)
		{
			Transform t0 = t1.GetChild(i);
			if(t0!=t1)
			{
				rc = t0.GetComponent(scriptName);
				i = t1.GetChildCount();
			}
		}
		return rc;
	}
	public static void setChildrenActiveRecursively(Transform t1,bool state)
	{
		for(int i=0; i<t1.GetChildCount(); i++)
		{
			Transform t0 = t1.GetChild(i);
			if(t0!=t1)
			{
				t0.gameObject.SetActive(state);
			}
		}
	}
}
