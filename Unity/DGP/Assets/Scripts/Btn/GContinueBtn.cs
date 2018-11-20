using UnityEngine;
using System.Collections;

// 일시정지 게임 계속하기 버튼 

public class GContinueBtn : MonoBehaviour {

    GPauseBtn m_csPause;  // GPauseBtn 스크립트 변수

    // Use this for initialization
    void Start()
    {
        m_csPause = GameObject.Find("PauseBtn").GetComponent<GPauseBtn>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 버튼 클릭시 일시정지 상태 적용 함수 호출
    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        m_csPause.OnClick();
    }
}
