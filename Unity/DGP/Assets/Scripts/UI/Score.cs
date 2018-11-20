using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    UILabel m_csUILabel; // UILabel 스크립트

    public int m_nScore; // 스코어

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
                    Debug.Log("Fail to get Score Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

	// Use this for initialization
	void Start () {

        m_csUILabel = transform.FindChild("Label").GetComponent<UILabel>();

        m_nScore = 0;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // 전달받은 수 만큼 스코어 증가
    public void AddScore(int nAddScore)
    {
        m_nScore += nAddScore;

        m_csUILabel.text = m_nScore.ToString();
    }
}
