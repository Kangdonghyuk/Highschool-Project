using UnityEngine;
using System.Collections;

public class GameMng : MonoBehaviour {

    public enum GAME_STATE
    {
        E_GAME_PLAY = 0,
        E_GAME_PAUSE,
        E_GAME_OVER
    }

    private static GameMng m_Instance = null;
    public static GameMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(GameMng)) as GameMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HFBGameMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    Transform m_cCardMng;
    Transform m_cFeverCardMng;

    public GAME_STATE m_eGameState;

	// Use this for initialization
	void Start () {
        m_cCardMng = transform.FindChild("Cards");
        m_cFeverCardMng = transform.FindChild("FeverCards");

        m_eGameState = GAME_STATE.E_GAME_PLAY;

        Debug.Log("APERsdfsdf");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Fever()
    {
        m_cCardMng.localPosition = new Vector3(-400.0f, 12.0f, 0.0f);
        m_cFeverCardMng.localPosition = new Vector3(0.0f, 12.0f, 0.0f);

        if (Application.loadedLevelName == "5_Game")
            FeverCardMng.I.Reset();
        else
            TutorialFeverCardMng.I.Reset();
    }

    public void NFever()
    {
        Debug.Log("APER");

        m_cCardMng.localPosition = new Vector3(0.0f, 12.0f, 0.0f);
        m_cFeverCardMng.localPosition = new Vector3(400.0f, 12.0f, 0.0f);

        if (Application.loadedLevelName == "5_Game")
        {
            CardMng.I.Reset();
            CardMng.I.JackReset();
        }
        else
        {
            TutorialCardMng.I.Reset();
            TutorialCardMng.I.JackReset();
        }
    }
}
