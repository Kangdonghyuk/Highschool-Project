using UnityEngine;
using System.Collections;

// �Ͻ����� ��ư

public class GPauseBtn : MonoBehaviour {

    Pause m_csPause; //Pause ��ũ��Ʈ ����

    //BoxCollider m_cBoxCollider;

    bool m_bPauseState; //���� ������ ���� üũ ����

	// Use this for initialization
	void Start () {
        m_csPause = GameObject.Find("Pause").GetComponent<Pause>();

        //m_cBoxCollider = GetComponent<BoxCollider>();

        m_bPauseState = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    // �Ͻ����� ���� ���� ����
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
