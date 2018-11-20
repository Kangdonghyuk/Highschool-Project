using UnityEngine;
using System.Collections;

public class Fever : MonoBehaviour {

    UISlider m_csUISlider; //UISlider 스크립트

    UISprite m_csSForegroundUISprite; // UISprite 스크립트

    FeverPang m_csFeverPang;

    Color m_stSForegroundColor; // 컬러변수
    bool m_bSForegroundState; // 컬러상태

    //Quaternion m_stShakeItQua;

   // bool m_bQuaState;
    /////////////////////////////////

    WaitForSeconds m_cWaitForSeconds; // 코루틴

    public bool m_bFeverState; // 피버상태

    float m_fPasent; // 게이지 깎기 퍼센트

    int m_nFeverTime;
    int m_nMaxFever; // 피버 맥스
    int m_nNowFever; // 현재 피버 게이지
    int m_nFeverCount; // 피버 끄지 카운트

	// Use this for initialization
	void Start () {
        m_csUISlider = transform.FindChild("Progress Bar").GetComponent<UISlider>();
        m_csSForegroundUISprite = transform.FindChild("Progress Bar").FindChild("Foreground").GetComponent<UISprite>();

        m_csFeverPang = GameObject.Find("FeverPang").GetComponent<FeverPang>();

        /////////////////////////////////
        m_stSForegroundColor = new Color(1.0f, 1.0f, 1.0f);
        m_bSForegroundState = false;
        /////////////////////////////////

        //m_stShakeItQua = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

        //m_bQuaState = false;

        ////////////////////////////////

        m_cWaitForSeconds = new WaitForSeconds(1.0f);

        m_bFeverState = false;

        m_nMaxFever = 44;
        m_nNowFever = 0;
        m_nFeverCount = 0;
        m_nFeverTime = 5;
        if (KDHManager.I.m_bFeverTimeUpState == true)
        {
            m_nFeverTime = 8;
        }

        m_fPasent = 1.0f / (float)m_nMaxFever;

        m_csUISlider.sliderValue = 0.0f;

        StartCoroutine("FeverUpdate");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            AddFever(100);

        if (m_bFeverState == false)
            m_csUISlider.sliderValue -= (m_fPasent * Time.deltaTime);
        else
        {
            if(m_nFeverTime == 5)
                m_csUISlider.sliderValue -= ((m_fPasent * 10.0f) * Time.deltaTime);
            else if(m_nFeverTime == 8)
                m_csUISlider.sliderValue -= ((m_fPasent * 6.0f) * Time.deltaTime);

            if (m_bSForegroundState == false)
            {
                m_stSForegroundColor.r = 0.8f;
                m_stSForegroundColor.g = 0.4f;
                m_stSForegroundColor.b = 0.4f;
                m_csSForegroundUISprite.color = m_stSForegroundColor;
                m_bSForegroundState = true;
            }
            else
            {
                m_stSForegroundColor.r = 1.0f;
                m_stSForegroundColor.g = 1.0f;
                m_stSForegroundColor.b = 1.0f;
                m_csSForegroundUISprite.color = m_stSForegroundColor;
                m_bSForegroundState = false;
            }
        }
	}

    // 전달받은 수 만큼 피버 게이지 증가
    public void AddFever(int nAddFever)
    {
        if (m_bFeverState == false)
        {
            m_nNowFever += nAddFever;

            if (m_nNowFever >= m_nMaxFever)
            {
                m_nNowFever = m_nMaxFever;
                m_nFeverCount = 0;
                
                //m_nNowFever = 0;

                m_csFeverPang.OnFever();

                GameMNG.I.SetGameState(GameMNG.GAME_STATE.E_GAME_FEVER);
                //PangMNG.I.Fever();
                m_bFeverState = true;
            }

            m_csUISlider.sliderValue = (m_nNowFever * m_fPasent);
        }
    }

    // 피버 체크
    IEnumerator FeverUpdate()
    {
        while (true)
        {
            if (m_bFeverState == false)
            {
                if (m_nNowFever > 0)
                {
                    m_nNowFever -= 1;
                }
            }
            else
            {
                m_nFeverCount += 1;
                if (m_nFeverCount >= m_nFeverTime)
                {
                    m_nFeverCount = 0;
                    m_nNowFever = 0;

                    m_csUISlider.sliderValue = 0.0f;

                    m_csFeverPang.OffFever();

                    GameMNG.I.SetGameState(GameMNG.GAME_STATE.E_GAME_PLAY);
                   // PangMNG.I.NFever();

                    m_stSForegroundColor.r = 1.0f;
                    m_stSForegroundColor.g = 1.0f;
                    m_stSForegroundColor.b = 1.0f;
                    m_csSForegroundUISprite.color = m_stSForegroundColor;

                    m_bFeverState = false;
                }
            }

            yield return m_cWaitForSeconds;
        }
    }
}
