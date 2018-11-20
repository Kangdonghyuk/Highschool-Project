using UnityEngine;
using System.Collections;
using System;

public class KDHManager : MonoBehaviour {

    private static KDHManager m_Instance = null;
    public static KDHManager I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(KDHManager)) as KDHManager;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get KDHManager Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

    public bool m_bBGSoundState;
    public bool m_bEfectSoundState;
    public bool m_bVibrateState;

    public int m_nPlayerMoney;

    public bool m_bTimeUpState;
    public bool m_bFeverTimeUpState;
    public bool m_bComboTimeUpState;
    public bool m_bPangResenNumAddState;
    public bool m_bPangKindSubState;
    public bool m_bFiveParsentAddState;

    public int[] m_nPlayerArray;

    public int m_nPlayerScore;

	// Use this for initialization
	void Start () {
        try
        {
            GameSateData.I.LoadData();
            m_nPlayerArray = GameSateData.I.myData.manage.nPlayerArray;
            m_nPlayerMoney = GameSateData.I.myData.manage.nPlayerMoney;
        }
        catch (Exception)
        {
            m_nPlayerArray = new int[5];
            for (int i = 0; i < 5; i++)
                m_nPlayerArray[i] = 0;
            m_nPlayerMoney = 0;
            GameSateData.I.SaveData();
        }

        m_bBGSoundState = true;
        m_bEfectSoundState = true;
        m_bVibrateState = true;

        m_bTimeUpState = false;
        m_bFeverTimeUpState = false;
        m_bPangResenNumAddState = false;
        m_bComboTimeUpState = false;
        m_bPangKindSubState = false;
        m_bFiveParsentAddState = false;

        m_nPlayerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
