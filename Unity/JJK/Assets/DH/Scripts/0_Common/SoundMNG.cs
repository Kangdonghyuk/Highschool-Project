using UnityEngine;
using System.Collections;
using System;
    
// ���� ����

public class SoundMNG : MonoBehaviour {

    public enum SOUND_KIND { // ���� ���� ����
        E_SOUND_ASS = 0,
        E_SOUND_CLEAR,
        E_SOUNE_OBER,
        E_SOUND_START,
        E_SOUND_TIMEUP,
        E_SOUND_FAIL,
        E_SOUND_PICKUP,
        E_SOUNE_MOUSEOVER
    }

    AudioListener m_cAudioListener; // ������� �����Ű�� ����� ������
    AudioSource m_cAudioSource; // ������� �����Ű�� ����� �ҽ�

   public AudioClip m_cBGSound;
   public AudioClip m_cSoundAss;
   public AudioClip m_cSoundClear;
   public AudioClip m_cSoundOber;
   public AudioClip m_cSoundStart;
   public AudioClip m_cSoundTimeUp;
   public AudioClip m_cSoundFail;
   public AudioClip m_cSoundPickUp;
   public AudioClip m_cSoundMouseOver;

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
        m_cAudioListener = GetComponent<AudioListener>();
        m_cAudioSource = m_cAudioListener.audio;

        m_cAudioSource.clip = m_cBGSound;
        m_cAudioSource.Play();

        SoundMNG.I.PlaySound(SOUND_KIND.E_SOUND_START);

	}

    void OnEnable()
    {
        m_cAudioListener = GetComponent<AudioListener>();
        m_cAudioSource = m_cAudioListener.audio;

            m_cAudioSource.clip = m_cBGSound;
                m_cAudioSource.Play();


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // �����ų ���� ���� �������� �ش��ϴ� ���� ���
    public void PlaySound(SOUND_KIND eSound_Kind)
    {
            switch (eSound_Kind)
            {
                case SOUND_KIND.E_SOUND_ASS:
                    m_cAudioSource.PlayOneShot(m_cSoundAss);
                    break;
                case SOUND_KIND.E_SOUND_CLEAR:
                    m_cAudioSource.PlayOneShot(m_cSoundClear);
                    break;
                case SOUND_KIND.E_SOUND_FAIL:
                    m_cAudioSource.PlayOneShot(m_cSoundFail);
                    break;
                case SOUND_KIND.E_SOUND_START:
                    m_cAudioSource.PlayOneShot(m_cSoundStart);
                    break;
                case SOUND_KIND.E_SOUND_TIMEUP:
                    m_cAudioSource.PlayOneShot(m_cSoundTimeUp);
                    break;
                case SOUND_KIND.E_SOUNE_OBER:
                    m_cAudioSource.PlayOneShot(m_cSoundOber);
                    break;
                case SOUND_KIND.E_SOUND_PICKUP:
                    m_cAudioSource.PlayOneShot(m_cSoundPickUp);
                    break;
                case SOUND_KIND.E_SOUNE_MOUSEOVER:
                    m_cAudioSource.PlayOneShot(m_cSoundMouseOver);
                    break;

            }
    }
}
