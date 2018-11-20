using UnityEngine;
using System.Collections;
using System;
    
// ���� ����

public class SoundMNG : MonoBehaviour {

    public enum SOUND_KIND { // ���� ���� ����
        E_SOUND_PANG = 0,
        E_SOUND_BOOM
    }

    AudioListener m_cAudioListener; // ������� �����Ű�� ����� ������
    AudioSource m_cAudioSource; // ������� �����Ű�� ����� �ҽ�

    AudioClip m_cBGSound;
    AudioClip m_cPangSound; // ���� ����� Ŭ�� ����(��)����
    AudioClip m_cBoomSound; // ���� ����� Ŭ�� ����(��ź)����

    private static SoundMNG m_Instance = null;
    public static SoundMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(SoundMNG)) as SoundMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get SoundMNG Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }
	// Use this for initialization
	void Start () {
       
        m_cBGSound = (AudioClip)Resources.Load("Sounds/GameBGM", typeof(AudioClip));
        m_cPangSound = (AudioClip)Resources.Load("Sounds/Pang",typeof(AudioClip));
        m_cBoomSound = (AudioClip)Resources.Load("Sounds/Boom", typeof(AudioClip));
	}

    void OnEnable()
    {
        if (Application.loadedLevelName == "HomiLogo")
        {
            m_cAudioListener = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        }
        if (Application.loadedLevelName == "DGPMenu")
        {
            m_cAudioListener = GameObject.Find("UI Root (2D)").transform.FindChild("Camera").GetComponent<AudioListener>();
        }
        else if (Application.loadedLevelName == "DGPGame")
        {
            m_cAudioListener = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        }
        else if (Application.loadedLevelName == "DGPGameOver")
        {
            m_cAudioListener = GameObject.Find("UI Root (2D)").transform.FindChild("Camera").GetComponent<AudioListener>();
        }
        else if (Application.loadedLevelName == "DGPRanking")
        {
            m_cAudioListener = GameObject.Find("UI Root (2D)").transform.FindChild("Camera").GetComponent<AudioListener>();
        }

        m_cAudioSource = m_cAudioListener.audio;

        if (Application.loadedLevelName == "DGPGame")
        {
            m_cAudioSource.clip = m_cBGSound;
            if (KDHManager.I.m_bBGSoundState == true)
            {
                m_cAudioSource.Play();
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // �����ų ���� ���� �������� �ش��ϴ� ���� ���
    public void PlaySound(SOUND_KIND eSound_Kind)
    {
        if (KDHManager.I.m_bEfectSoundState == true)
        {
            switch (eSound_Kind)
            {
                case SOUND_KIND.E_SOUND_PANG:
                    m_cAudioSource.PlayOneShot(m_cPangSound);
                    break;
                case SOUND_KIND.E_SOUND_BOOM:
                    m_cAudioSource.PlayOneShot(m_cBoomSound);
                    break;
            }
        }
    }
}
