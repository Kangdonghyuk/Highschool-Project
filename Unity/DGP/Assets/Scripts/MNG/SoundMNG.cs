using UnityEngine;
using System.Collections;
using System;
    
// 사운드 관리

public class SoundMNG : MonoBehaviour {

    public enum SOUND_KIND { // 사운드 종류 열거
        E_SOUND_PANG = 0,
        E_SOUND_BOOM
    }

    AudioListener m_cAudioListener; // 현재씬의 재생시키는 오디오 리스너
    AudioSource m_cAudioSource; // 현재씬의 재생시키는 오디오 소스

    AudioClip m_cBGSound;
    AudioClip m_cPangSound; // 사운드 오디오 클립 저장(팡)변수
    AudioClip m_cBoomSound; // 사운드 오디오 클립 저장(폭탄)변수

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

    // 재생시킬 사운드 종류 받은다음 해당하는 사운드 출력
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
