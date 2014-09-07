using UnityEngine;
using System.Collections;

public class MenuStateManager  {

	public delegate void OnEnterState(string stateID);
	public static event OnEnterState onEnterState;
	public static void enterState(string stateID)
	{
		if(onEnterState!=null)
		{
			onEnterState(stateID);
		}
	}
	public static void enterStateUsingName(string name)
	{
		BaseMenuState bms = getState(name);
		string stateID = "";
		if(bms)
		{
			stateID = bms.getStateID();

		}
		if(onEnterState!=null)
		{
			onEnterState(stateID);
		}		
	}

	public static void enterStateUsingGameObject(GameObject go)
	{
		BaseMenuState bms = getState(go);
		string stateID = "";
		if(bms)
		{
			stateID = bms.getStateID();

		}
		if(onEnterState!=null)
		{
			onEnterState(stateID);
		}		
	}
	public static BaseMenuState getState(GameObject go)
	{
		BaseMenuState bms = null;
		if(go){
			bms = go.GetComponent<BaseMenuState>();
		}
		return bms;
	}	
	public static BaseMenuState getState(string name)
	{
		BaseMenuState bms = null;
		GameObject go = GameObject.Find(name);
		if(go){
			bms = go.GetComponent<BaseMenuState>();
		}
		return bms;
	}
}
