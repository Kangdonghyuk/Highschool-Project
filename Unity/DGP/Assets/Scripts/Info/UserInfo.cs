using UnityEngine;
using System.Collections;

public class UserInfo : MonoBehaviour {

    public struct UserInfomation
    {
        string m_sUserName;
        int m_nUserMoney;
        int m_nUserHighScore;

        public UserInfomation(string sUserName, int nUserMoney, int nUserHighScore)
        {
            m_sUserName = sUserName;
            m_nUserMoney = nUserMoney;
            m_nUserHighScore = nUserHighScore;
        }

        public void SetUserAllInfo(UserInfomation stUserInfomation)
        {
            this = stUserInfomation;
        }
        public void SetUserAllInfo(string sUserName, int nUserMoney, int nUserHighScore)
        {
            m_sUserName = sUserName;
            m_nUserMoney = nUserMoney;
            m_nUserHighScore = nUserHighScore;
        }
        public void SetUserName(string sUserName)
        {
            m_sUserName = sUserName;
        }
        public void SetUserMoney(int nUserMoney)
        {
            m_nUserMoney = nUserMoney;
        }
        public void SetUserHighScore(int nUserHighMoney)
        {
            m_nUserHighScore = nUserHighMoney;
        }

        public string GetUserName()
        {
            return m_sUserName;
        }
        public int GetUserMoney()
        {
            return m_nUserMoney;
        }
        public int GetUserHighScore()
        {
            return m_nUserHighScore;
        }
    };

    UserInfomation m_stUserInfo;

    private static UserInfo m_Instance = null;
    public static UserInfo I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(UserInfo)) as UserInfo;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get UserInfo Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);

        m_stUserInfo = new UserInfomation("None", 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public UserInfomation GetUserInfo()
    {
        return m_stUserInfo;
    }
}
