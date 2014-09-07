using UnityEngine;
using System.Collections;

/*
	Simple credit state
*/
public class CreditState : BaseMenuState 
{	
	#region variables
	//our main gameobject
	public GameObject mainMenuGO;
	
	//the background texture
	public Texture backgroundTexture;
	
	
	//the time before switching the credits
	public float fadeTime = 1f;
	
	private float m_fadeTime;
	//our current title
	private int m_index=0;
	
	//both jobs and authors should be the same number of strings!
	public string[] jobs = {"Crack","Jose Galindo"};
	
	//a list of authors
	public string[] workers = {"Justin","Ivan"};

	#endregion

	public void Start()
	{
		m_index=0;
	
		//call roll credits
//		StartCoroutine(rollCredits());
	}
	void Update()
	{
		m_fadeTime-=Time.deltaTime;
		if(m_fadeTime<0)
		{
			m_fadeTime=fadeTime;
			int n = jobs.Length;
			m_index++;
			Debug.Log ("Index"+m_index);
			if(m_index>=n)
			{
				m_index=0;
			}
		}
	}
	
	
	public override void onGUI()
	{
		GUI.skin = guiSkin0;
		
		float offsetX = transform.position.x+ MenuConstants.OFFSET_X;
		float offsetY = transform.position.y +MenuConstants.OFFSET_Y;
		
		if(backgroundTexture)
		{
			GUI.DrawTexture( GUIHelper.screenRect(0,0,1,1),backgroundTexture);
		}
		if(m_done)
		{
			GUI.Label( GUIHelper.screenRect(0.55f,0.4f,.6f,.1f),jobs[m_index]);
			GUI.Label( GUIHelper.screenRect(0.575f,0.5f,.6f,.1f),workers[m_index]);
		}
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY,.45f,.89f), "Rules: tenes que ingresar a la zona verde, \n presionar space, esperar 5 segundos y salir \npara la zona donde hay que dejar al pasajero\t");

		
		if( addButton (GUIHelper.screenRect (offsetX+.05f,offsetY+.775f,.35f,.1f) ," Main Menu"))
		{
			
			//deactivate this object and activate teh main menu object
			swapObjects(mainMenuGO);
			
		}
	}
	

	
}
