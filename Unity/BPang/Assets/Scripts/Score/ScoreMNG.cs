using UnityEngine;
using System.Collections;

public class ScoreMNG : MonoBehaviour
{

    ScoreLabel m_csScoreLabel;

    private GameObject currnetObject = null;
    private static ScoreMNG m_Instance = null;
    public static ScoreMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(ScoreMNG)) as ScoreMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get ScoreMNG Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

    /**
    @brief     : 초기화
    @return : void
    */
	// Use this for initialization
	void Start () {
        m_csScoreLabel = transform.FindChild("Label").gameObject.GetComponent<ScoreLabel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
	@brief     : 스코어추가
	@return : void
    */
    public void AddScore(int nScore)
    {
        m_csScoreLabel.AddScore(nScore);
    }
}
