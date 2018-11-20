using UnityEngine;
using System.Collections;

public class RankMNG : MonoBehaviour {

    UILabel[] m_csUILabel = new UILabel[5];

    int[] m_nPlayerArray = new int[5];

    private static RankMNG m_Instance = null;
    public static RankMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(RankMNG)) as RankMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get RankMNG Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 5; i++)
        {
            m_csUILabel[i] = transform.FindChild("Rank" + (i + 1).ToString() + "Text").
                GetComponent<UILabel>();
            m_nPlayerArray[i] = 0;
        }

        m_nPlayerArray = KDHManager.I.m_nPlayerArray;

        if (m_nPlayerArray[4] < KDHManager.I.m_nPlayerScore)
        {
            m_nPlayerArray[4] = KDHManager.I.m_nPlayerScore;
        }

        KDHManager.I.m_nPlayerScore = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = i; j < 5; j++)
            {
                if (m_nPlayerArray[i] < m_nPlayerArray[j])
                {
                    int nTemp = m_nPlayerArray[i];
                    m_nPlayerArray[i] = m_nPlayerArray[j];
                    m_nPlayerArray[j] = nTemp;
                }
            }
        }

        for (int i = 0; i < 5; i++)
        {
            m_csUILabel[i].text = m_nPlayerArray[i].ToString();
        }

        GameSateData.I.SaveDataRank();
	}

    // Update is called once per frame
    void Update()
    {
	
	}

    public void Reset()
    {
        for (int i = 0; i < 5; i++)
        {
            m_nPlayerArray[i] = 0;
            m_csUILabel[i].text = m_nPlayerArray[i].ToString();
        }
        KDHManager.I.m_nPlayerArray = m_nPlayerArray;

        GameSateData.I.SaveDataRank();
    }
}
