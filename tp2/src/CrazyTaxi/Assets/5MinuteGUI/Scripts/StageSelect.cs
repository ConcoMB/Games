using UnityEngine;
using System.Collections;

public class StageSelect : BaseMenuState {

	#region variables
	public Vector2 offset;
	//our main gameobject
	public GameObject mainMenuGO;
	
	//the background texture
	public Texture backgroundTexture;
	
	
	//our gui skin!

	public int levelsPerRow = 3;
	public int levelsPerCol = 4;

	private int m_maxPages = 0;
	
	private int m_page = 0;
	
	public int maxLevels = 30;
	
	public string stageSelectSTR = "Stage Select";
	public string levelPrefix = "Level ";
	public string mainMenuButtonSTR = "Main Menu";
	
	public string nextPageButtonSTR = ">>";
	public string prevPageButtonSTR = "<<";
	
	public Vector2 levelButtonSize = new Vector2(0.2f,0.1f);
	public Vector2 buttonSpaceOffset;
	public bool useLevelNames=false;
	public string[] levelNames = {"Box Runner","Warp and Run"};
	
	public bool dontLockLevels = false;
	#endregion
	public void Start()
	{
		int n = 0;
		while(n < maxLevels)
		{
			m_maxPages++;
			n+= (levelsPerCol * levelsPerRow);
		}
	}
	
	
	public override void onGUI()
	{
		GUI.skin = guiSkin0;
		
		float offsetX = transform.position.x + offset.x;
		float offsetY = transform.position.y + offset.y;
		
		if(backgroundTexture)
		{
			GUI.DrawTexture( GUIHelper.screenRect(0,0,1,1),backgroundTexture);
		}
				GUI.Box (GUIHelper.screenRect (offsetX,offsetY-.1f,.9f,.725f) ,"");
		
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY-.1f,.9f,.725f) ,stageSelectSTR);
		
		int n = 1 + m_page * levelsPerCol * levelsPerRow;
		for(int i=0; i<levelsPerRow; i++)
		{
			for(int j=0; j<levelsPerCol; j++)
			{
				int levelX = n;
				string str = levelPrefix + levelX.ToString();
				if(useLevelNames && n-1 < levelNames.Length)
				{
					str = levelNames[n-1];	
				}
				if(n<=maxLevels)
				{
					if(n <= Misc.getMaxLevel() || dontLockLevels)
					{
						GUI.enabled=true;
						if( addButton (GUIHelper.screenRect (offsetX+.05f+j*(levelButtonSize.x+buttonSpaceOffset.x),
												offsetY+i*(levelButtonSize.y+buttonSpaceOffset.y),
												levelButtonSize.x,levelButtonSize.y) ,
							str))
						{

							
							Application.LoadLevel(n);
						}
					}else{
						GUI.enabled=false;
						addButton(GUIHelper.screenRect (offsetX+.05f+j*(levelButtonSize.x+buttonSpaceOffset.x),
													offsetY+i*(levelButtonSize.y+buttonSpaceOffset.y),
													levelButtonSize.x,levelButtonSize.y) ,
							str);					
					}
					n++;
				}
			}
		}
		GUI.enabled=true;
		//only show if we have more tahn 1 page.
		if(m_maxPages>1)
		{
			if( addButton (GUIHelper.screenRect (offsetX+0.05f,offsetY+.325f,.15f,.1f) ,prevPageButtonSTR))
			{
				m_page--;
				if(m_page<0)
				{
					m_page = m_maxPages-1;
				}	

			}
			if( addButton (GUIHelper.screenRect (offsetX+.7f,offsetY+.325f,.15f,.1f) ,nextPageButtonSTR))
			{
				m_page++;
				if(m_page>m_maxPages-1)
				{
					m_page = 0;
				}
			}	
		}
		
		
		if( addButton (GUIHelper.screenRect (offsetX+.3f,offsetY+.45f,.3f,.1f) ,mainMenuButtonSTR))
		{
			
			swapObjects(mainMenuGO);
		}
	}
	
}
