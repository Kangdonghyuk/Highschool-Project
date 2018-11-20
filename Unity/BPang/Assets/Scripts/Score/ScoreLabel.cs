using UnityEngine;
using System.Collections;

public class ScoreLabel : MonoBehaviour {

    UILabel m_csUILabel;

    Vector3 m_stScale;

    int m_nScore;
    int m_nLabelScore;

    /**
    @brief     : �ʱ�ȭ
    @return : void
    */
	// Use this for initialization
	void Start () {
        m_csUILabel = GetComponent<UILabel>();

        m_stScale = new Vector3(50.0f, 50.0f, 0.0f);

        m_nScore = 0;
        m_nLabelScore = 0;
	}

    /**
    @brief     : ���ھ� �÷��ֱ�
    @return : void
    */
	// Update is called once per frame
	void Update () {
        m_stScale.x = 50.0f;
        m_stScale.y = 50.0f;

        if (m_nLabelScore < m_nScore)
        {
            m_nLabelScore+= (int)Random.Range(1.0f, 100.0f);
            m_stScale.x = 60.0f;
            m_stScale.y = 60.0f;
            if (m_nLabelScore > m_nScore)
                m_nLabelScore = m_nScore;
        }

        transform.localScale = m_stScale;

        m_csUILabel.text = m_nLabelScore.ToString();
	}

    /**
	@brief     : ���ھ� �ø���
	@return : void
    */
    public void AddScore(int nScore)
    {
        m_nScore += nScore;
    }
}
