using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    private static Score m_Instance = null;
    public static Score I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(Score)) as Score;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HFBGameMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    UILabel m_csUILabel;

    public int m_nSuccessNum;

	// Use this for initialization
	void Start () {
        m_csUILabel = transform.GetComponent<UILabel>();

        m_nSuccessNum = 0;

        m_csUILabel.text = m_nSuccessNum.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddScore()
    {
        m_nSuccessNum += 1;

        m_csUILabel.text = m_nSuccessNum.ToString();
    }
}
