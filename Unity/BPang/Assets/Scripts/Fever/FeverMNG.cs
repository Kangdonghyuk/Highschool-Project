using UnityEngine;
using System.Collections;

public class FeverMNG : MonoBehaviour {

    FeverGage m_csFeverGage;

    AudioClip m_cFever_Sound;

    float m_fPassTime;
    float m_fSecondTime;
    float m_fFeverTime;

    int m_nFeverGage;

    bool m_bFeverState;

    private GameObject currnetObject = null;
    private static FeverMNG m_Instance = null;
    public static FeverMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(FeverMNG)) as FeverMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get FeverMNG Instance");
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

        m_csFeverGage = transform.FindChild("Slider").gameObject.GetComponent<FeverGage>();

        m_cFever_Sound = (AudioClip)Resources.Load("Sound/Game/Fever/Fever", typeof(AudioClip));

        m_fPassTime = 0.0f;
        m_fSecondTime = 1.0f;
        m_fFeverTime = 10.0f;

        m_nFeverGage = 0;

        m_bFeverState = false;
	}

    /**
    @brief     : 피버 상태인지 확인
    @return : void
    */
	// Update is called once per frame
	void Update () {
        m_fPassTime += Time.deltaTime;

        m_csFeverGage.SetFeverGageValue(m_nFeverGage / 77.0f);

        if (m_bFeverState == false)
        {
           if (m_fPassTime > m_fSecondTime)
            {
                if (m_nFeverGage > 0)
                {
                    m_nFeverGage--;
                }
                m_fSecondTime = m_fPassTime + 1.0f;
            }

            if (m_nFeverGage >= 77)
            {
                CreatePangMNG.I.Fever();
                m_nFeverGage = 77;
                m_fFeverTime = m_fPassTime + 10.0f;

                Handheld.Vibrate();
                NGUITools.PlaySound(m_cFever_Sound);

                m_bFeverState = true;
            }
        }
        else if (m_bFeverState == true)
        {
            if (m_fPassTime > m_fFeverTime)
            {
                m_nFeverGage = 0;
                CreatePangMNG.I.NFever();
                m_bFeverState = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            m_nFeverGage = 77;
        }
	}

    /**
	@brief     : 피버 게이지 추가
	@return : void
    */
    public void AddFeverGage(int nFeverGage)
    {
        m_nFeverGage += nFeverGage;
    }

    /**
	@brief     : 피버 상태 반환
	@return : bool<피버상태>
    */
    public bool GetFeverState()
    {
        return m_bFeverState;
    }
}
