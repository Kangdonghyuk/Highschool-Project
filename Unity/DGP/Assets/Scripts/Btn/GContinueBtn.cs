using UnityEngine;
using System.Collections;

// �Ͻ����� ���� ����ϱ� ��ư 

public class GContinueBtn : MonoBehaviour {

    GPauseBtn m_csPause;  // GPauseBtn ��ũ��Ʈ ����

    // Use this for initialization
    void Start()
    {
        m_csPause = GameObject.Find("PauseBtn").GetComponent<GPauseBtn>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ��ư Ŭ���� �Ͻ����� ���� ���� �Լ� ȣ��
    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        m_csPause.OnClick();
    }
}
