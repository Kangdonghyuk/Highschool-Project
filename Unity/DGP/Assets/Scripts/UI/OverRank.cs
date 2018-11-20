using UnityEngine;
using System.Collections;

public class OverRank : MonoBehaviour {

    int[] m_nPlayerArray = new int[5];

    int m_nRank;

    UILabel m_csUILabel;

	// Use this for initialization
	void Start () {

        m_csUILabel = GetComponent<UILabel>();

        m_nRank = 0;

        m_nPlayerArray = KDHManager.I.m_nPlayerArray;

        if (m_nPlayerArray[4] <= KDHManager.I.m_nPlayerScore)
        {
            m_nRank = 5;
        }
        if (m_nPlayerArray[3] <= KDHManager.I.m_nPlayerScore)
        {
            m_nRank = 4;
        }
        if (m_nPlayerArray[2] <= KDHManager.I.m_nPlayerScore)
        {
            m_nRank = 3;
        }
        if (m_nPlayerArray[1] <= KDHManager.I.m_nPlayerScore)
        {
            m_nRank = 2;
        }
        if (m_nPlayerArray[0] <= KDHManager.I.m_nPlayerScore)
        {
            m_nRank = 1;
        }

        if (m_nRank == 0)
        {
            m_csUILabel.text = "Over Rank";
        }
        else
        {
            m_csUILabel.text = m_nRank.ToString();
        }

	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
