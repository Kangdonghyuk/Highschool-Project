using UnityEngine;
using System.Collections;

public class TimeBar : MonoBehaviour {

    private static TimeBar m_Instance = null;
    public static TimeBar I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(TimeBar)) as TimeBar;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HFBTimeBar.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    UISlider m_csUISlider;

    Transform m_cTimeClock;

    float m_fPasent;

	// Use this for initialization
	void Start () {
        m_csUISlider = transform.GetComponent<UISlider>();

        m_cTimeClock = transform.FindChild("TimeClock");

        m_fPasent = 1.0f / 60.0f;
        Debug.Log(m_fPasent);
	}
	
	// Update is called once per frame
	void Update () {
        m_cTimeClock.localPosition = new Vector3(m_cTimeClock.localPosition.x, (-380.0f + ((m_csUISlider.sliderValue*100) * 7.6f)), m_cTimeClock.localPosition.z);

        m_csUISlider.sliderValue -= (m_fPasent * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.H))
        {
            AddTime(2.0f);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            AddTime(-1.0f);
        }

        if (GameMng.I.m_eGameState == GameMng.GAME_STATE.E_GAME_PLAY)
        {
            if (m_csUISlider.sliderValue == 0.0f)
            {
                SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_TIMEUP);
                GameMng.I.m_eGameState = GameMng.GAME_STATE.E_GAME_OVER;
                HPMng.I.m_nUserScore = Score.I.m_nSuccessNum;
                Application.LoadLevel("2_Menu");
            }
        }
	}

    public void AddTime(float nAddTime)
    {
        m_csUISlider.sliderValue += (m_fPasent * nAddTime);
    }
}
