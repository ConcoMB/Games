using UnityEngine;
using System.Collections;

public class BaseMenuState : MonoBehaviour {
	private float m_moveTime = 0;
	public float moveTime = .5f;
	public Vector3 startPos = new Vector3(-1,0,0);
	public Vector3 endPos = new Vector3(0,0,0);
	protected bool m_done = true;
	
	private float m_dir = 1;
	
	protected string m_stateID;
	protected bool m_on = false;
	public GUISkin guiSkin0;
	
	public bool alwaysOn = false;
	private int m_buttonIndex = 0;
	private int m_buttonCount = 0;
	private int m_selectedButton = 0;
	private bool m_useSelectedButton = false;
	
	public KeyCode nextCode = KeyCode.UpArrow;
	public KeyCode prevCode = KeyCode.DownArrow;
	
	
	public virtual void Awake()
	{
		m_stateID = gameObject.name;
	}
	public void clear()
	{
		m_buttonIndex = 0;
	}

	public bool addButton(Rect r, string str)
	{
		bool rc = false;
		if(m_buttonIndex==m_selectedButton)
		{
			GUIStyle gs = null;
			if(guiSkin0)
			{
				gs = guiSkin0.GetStyle("Selected");
			}
			if(GUI.Button (r, str,gs ) || m_useSelectedButton)
			{
				rc=true;
				m_useSelectedButton = false;
			}
		}else{
			if(GUI.Button (r, str))	
			{
				rc=true;
			}
		}
		m_buttonIndex++;
		return rc;
	}
	
	public virtual void OnEnable()
	{
		MenuStateManager.onEnterState += onEnterState;
	}
	public virtual  void OnDisable()
	{
		MenuStateManager.onEnterState -= onEnterState;
	}
	public string getStateID()
	{
		return m_stateID;
	}
	public virtual void onEnterState(string sid)
	{
		if(m_stateID.Equals(sid))
		{
			if(m_on==false)
			{
				enable();
			}
			
			m_on = true;
		}else{
			if(m_on)
			{
				disable();
			}

		}
	}
	public void OnGUI()
	{
		if(m_on || alwaysOn)
		{
			clear ();
			onGUI();
		}
	}
	public virtual void onGUI(){}
	
	public void swapObjects(GameObject go)
	{
		MenuStateManager.enterStateUsingGameObject( go );
	}

	void enable()
	{
		if(m_done)
		{
			m_on=true;
			m_dir=1;
			m_done = false;
			m_moveTime=0;
			m_moveTime = Time.realtimeSinceStartup; 
			
			transform.position = startPos;
		}
	}
	public void disable(int cmd=-1)
	{
		m_done = false;
		m_moveTime = 0 + Time.realtimeSinceStartup;
		m_dir=-1;
		transform.position = endPos;
		
	}
	void LateUpdate()
	{
			if(m_on)
			{
				handleInput();
			}
		if(m_done==false)
		{

			float v = Time.realtimeSinceStartup - m_moveTime;
			float val = v / moveTime;

			if(val>1 )
			{
				val = 1;
				m_done = true;
				if(m_dir==-1)
				{
					m_on = false;
				}
			}
			if(m_dir>0)
			{
				transform.position = Vector3.Lerp(startPos,endPos,val);
			}else{
				transform.position = Vector3.Lerp(endPos,startPos,val);
			}
		}
	}
	public void handleInput()
	{
		if(Input.GetKeyDown(nextCode))
		{
			m_selectedButton--;
			if(m_selectedButton < 0)
			{
				m_selectedButton = 0;
			}
		}
		if(Input.GetKeyDown(prevCode))
		{
			m_selectedButton++;
			if(m_selectedButton > m_buttonIndex-1)
			{
				m_selectedButton = m_buttonIndex-1;
			}
			
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			m_useSelectedButton = true;
		}
	}

}
