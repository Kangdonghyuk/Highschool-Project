using UnityEngine;
using System.Collections;



public class GameSateData : MonoBehaviour 
{
    private static GameSateData m_Instance = null;

    public static GameSateData I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(GameSateData)) as GameSateData;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get Manager Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }



   public UILabel DebugLogLabel = null;

   public ManagerData myData = null;
   private string _data; 

   void Awake () 
	{ 
	    myData=new ManagerData();

        //Screen.SetResolution(1280, (1280 / 16) * 10, true);        
        //Screen.SetResolution(800, 480, true);

        //! 절전모드로 안들어가게 함입니다
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //Application.runInBackground = true;

        //! 프레임 고정
        //Application.targetFrameRate = 30;
    }
	
    public void SaveData()
	{
        ManageData();
	    _data = GameStateXML.SerializeObject(myData,"ManagerData");
        GameStateXML.CreateXML("DGP.xml", _data);

        //DebugLogLabel.text = _data.ToString();// Debug.Log(_data);
	}

    public void LoadData()
	{
        _data = GameStateXML.LoadXML("DGP.xml");
		
        if(_data.ToString() != "") 
	    {
            myData = (ManagerData)GameStateXML.DeserializeObject(_data,"ManagerData");
	    }
	}

	
    public void ManageData()
    {
        myData.manage.nPlayerArray = HPMng.I.m_nScore;
        myData.manage.m_TutoState = HPMng.I.m_bTutoState;
    }


}
