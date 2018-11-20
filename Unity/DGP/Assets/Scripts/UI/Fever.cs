using UnityEngine;
using System.Collections;

public class Fever : MonoBehaviour {

    UISlider m_csUISlider; //UISlider ��ũ��Ʈ

    UISprite m_csSForegroundUISprite; // UISprite ��ũ��Ʈ

    FeverPang m_csFeverPang;

    Color m_stSForegroundColor; // �÷�����
    bool m_bSForegroundState; // �÷�����

    //Quaternion m_stShakeItQua;

   // bool m_bQuaState;
    /////////////////////////////////

    WaitForSeconds m_cWaitForSeconds; // �ڷ�ƾ

    public bool m_bFeverState; // �ǹ�����

    float m_fPasent; // ������ ��� �ۼ�Ʈ

    int m_nFeverTime;
    int m_nMaxFever; // �ǹ� �ƽ�
    int m_nNowFever; // ���� �ǹ� ������
    int m_nFeverCount; // �ǹ� ���� ī��Ʈ

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

    // ���޹��� �� ��ŭ �ǹ� ������ ����
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

    // �ǹ� üũ
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
