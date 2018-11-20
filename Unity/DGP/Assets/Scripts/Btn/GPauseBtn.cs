using UnityEngine;
using System.Collections;

// 일시정지 버튼

public class GPauseBtn : MonoBehaviour {

    Pause m_csPause; //Pause 스크립트 변수

    //BoxCollider m_cBoxCollider;

    bool m_bPauseState; //현재 게임의 상태 체크 변수

	// Use this for initialization
	void Start () {
        m_csPause = GameObject.Find("Pause").GetComponent<Pause>();

        //m_cBoxCollider = GetComponent<BoxCollider>();

        m_bPauseState = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    // 일시정지 상태 변경 적용
    public void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        m_bPauseState = !m_bPauseState;
        m_csPause.OnOffPause();
        if (m_bPauseState == true)
        {
            //m_cBoxCollider.enabled = false;
            GameMNG.I.OnOffGamePause();
        }
        else
        {
            //m_cBoxCollider.enabled = true;
            GameMNG.I.OnOffGamePause();
        }
    }
}
