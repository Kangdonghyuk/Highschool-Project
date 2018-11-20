using UnityEngine;
using System.Collections;
using System;

public class HPMng : MonoBehaviour {
    public int[] m_nScore = null;

    public int m_nUserScore;

    public bool m_bTutoState;

    static HPMng m_cInstance = null;

    public static HPMng I
    {
        get
        {
            if (m_cInstance == null)
            {
                m_cInstance = FindObjectOfType(typeof(HPMng)) as HPMng;

                if (m_cInstance == null)
                {
                    Debug.Log("Fail to get HPMng Instance");    
                    return null;
                }
            }

            return m_cInstance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {

        m_nUserScore = 0;
        m_bTutoState = true;
        m_nScore = new int[5];
        for (int i = 0; i < 5; i++)
        {
            m_nScore[i] = 0;
        }

        try
        {
            GameSateData.I.LoadData();
        }
        catch (Exception)
        {
            GameSateData.I.SaveData();

        }

        m_bTutoState = GameSateData.I.myData.manage.m_TutoState;

        m_nScore = GameSateData.I.myData.manage.nPlayerArray;

        for (int i = 0; i < 5; i++)
        {
            for (int j = i; j < 5; j++)
            {
                if (m_nScore[i] < m_nScore[j])
                {
                    int temp = m_nScore[i];
                    m_nScore[i] = m_nScore[j];
                    m_nScore[j] = temp;
                }
            }
        }

        GameSateData.I.SaveData();
	}

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName == "2_Menu" && m_nUserScore != 0)
        {
            if(m_nUserScore > m_nScore[4])
            {
                m_nScore[4] = m_nUserScore;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = i; j < 5; j++)
                {
                    if (m_nScore[i] < m_nScore[j])
                    {
                        int temp = m_nScore[i];
                        m_nScore[i] = m_nScore[j];
                        m_nScore[j] = temp;
                    }
                }
            }

            m_nUserScore = 0;
            GameSateData.I.SaveData();
        }
	}
}
