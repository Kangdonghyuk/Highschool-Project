using UnityEngine;
using System.Collections;

public class Timemer : MonoBehaviour {

    UISlider m_csUISlider; // UISlider 스크립트
    UILabel m_csUILabel; // UILabel 스크립트(시간 표시)

    ////////////////////
    public tk2dSprite m_cstGameBGk2dSprite; // tk2dSprite 스크립트(게입 배경)
    Color m_stGameBGColor; // 게임 배경 컬러
    float m_fGameBGPasent; // 게임 배경 컬러 감소 퍼센트
    ////////////////////

    WaitForSeconds m_cWaitForSeconds; // 코루틴

    Color m_stForegroundColor;
    UIFilledSprite m_csForegroundUIFilledSprite;
    bool m_bHurryUp;
    bool m_bForegroundColorState;

    float m_fPasent; // 게이지 깎기 퍼센트

    public int m_nMaxTime; // 최대시간
    public int m_nPlayTime; // 플레이 시간

	// Use this for initialization
	void Start () {
        m_csUISlider = transform.FindChild("Progress Bar").GetComponent<UISlider>();
        m_csUILabel = transform.FindChild("Label").GetComponent<UILabel>();

        m_stGameBGColor = new Color(1.0f, 1.0f, 1.0f);

        //m_fGameBGPasent = m_fGameBGPasent * 0.005f;
       // Debug.Log(m_fGameBGPasent);

        m_stForegroundColor = new Color(1.0f, 1.0f, 1.0f);
        m_csForegroundUIFilledSprite = transform.FindChild("Progress Bar").FindChild("Foreground").GetComponent<UIFilledSprite>();
        m_bHurryUp = false;
        m_bForegroundColorState = false;

        m_cWaitForSeconds = new WaitForSeconds(1.0f);

        m_nMaxTime = 60;
        if (KDHManager.I.m_bTimeUpState == true)
        {
            m_nMaxTime = 90;
        }  
        m_fGameBGPasent = (1.0f / ((float)m_nMaxTime + 20.0f));
        m_nPlayTime = 0;

        m_csUILabel.text = m_nMaxTime.ToString();
        
        m_fPasent = 1.0f / (float)m_nMaxTime;

        StartCoroutine("TimeUpdate");
	}
	
	// Update is called once per frame
	void Update () {
        if (GameMNG.I.m_eGame_State == GameMNG.GAME_STATE.E_GAME_PLAY)
        {
            m_csUISlider.sliderValue -= (m_fPasent * Time.deltaTime);
        }
        /*if (m_nPlayTime < m_nMaxTime)
        {
            m_stGameBGColor.r -= (m_fGameBGPasent * Time.deltaTime);
            m_stGameBGColor.g -= (m_fGameBGPasent * Time.deltaTime);
            m_stGameBGColor.b -= (m_fGameBGPasent * Time.deltaTime);
            m_cstGameBGk2dSprite.color = m_stGameBGColor;
        }*/

        if (m_bHurryUp == true)
        {
            if (m_bForegroundColorState == true)
            {
                m_stForegroundColor.g -= 2.5f * Time.deltaTime;
                m_stForegroundColor.b -= 2.5f * Time.deltaTime;
                m_csForegroundUIFilledSprite.color = m_stForegroundColor;

                if (m_csForegroundUIFilledSprite.color.g <= 0.1f)
                    m_bForegroundColorState = false;
            }
            else
            {
                m_stForegroundColor.g += 2.5f * Time.deltaTime;
                m_stForegroundColor.b += 2.5f * Time.deltaTime;
                m_csForegroundUIFilledSprite.color = m_stForegroundColor;
                if (m_csForegroundUIFilledSprite.color.g >= 0.9f)
                    m_bForegroundColorState = true;
            }
        }
	}

    // 타임 체크, 1초당 배경 어둡게
    IEnumerator TimeUpdate()
    {
        while (true)
        {
            if (GameMNG.I.m_eGame_State == GameMNG.GAME_STATE.E_GAME_PLAY)
            {
                m_nPlayTime += 1;

                m_csUILabel.text = (m_nMaxTime - m_nPlayTime).ToString();

                m_stGameBGColor.r -= (m_fGameBGPasent);
                m_stGameBGColor.g -= (m_fGameBGPasent);
                m_stGameBGColor.b -= (m_fGameBGPasent);
                m_cstGameBGk2dSprite.color = m_stGameBGColor;

                if ((m_nMaxTime - m_nPlayTime) == 10)
                {
                    m_bHurryUp = true;
                }
                if (m_nPlayTime == m_nMaxTime)
                {
                    GameObject.Find("ReadyStart").GetComponent<ReadyStart>().StartCoroutine("OverText");

                    PangMNG.I.DUp();

                    GameMNG.I.SetGameState(GameMNG.GAME_STATE.E_GAME_OVER);

                    m_bHurryUp = false;

                    StartCoroutine("TimeUpdate");
                    /*Application.LoadLevel("DGPGameOver");
                    Resources.UnloadUnusedAssets();
                    System.GC.Collect();*/
                }
            }

            yield return m_cWaitForSeconds;
        }
    }
}
