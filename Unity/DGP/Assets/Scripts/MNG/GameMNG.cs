using UnityEngine;
using System.Collections;

// 게임의 전반적인 데이터 저장 

public class GameMNG : MonoBehaviour {

    public enum GAME_STATE // 게임의 상태 열거
    {
        E_GAME_NONE = 0,
        E_GAME_PLAY = 1,
        E_GAME_FEVER = 2,
        E_GAME_PAUSE = 3,
        E_GAME_OVER = 4
    }

    public GAME_STATE m_eGame_State; // 현재 게임의 상태 변수
    public GAME_STATE m_eBeforeGame_State; // 이전 게임의 상태 변수

    private static GameMNG m_Instance = null;
    public static GameMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(GameMNG)) as GameMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get GameMNG Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

    void Awake()
    {   
        //Screen.SetResolution(480, 800, true);
    }
	// Use this for initialization
	void Start () {
        m_eGame_State = GAME_STATE.E_GAME_NONE;
        m_eBeforeGame_State = GAME_STATE.E_GAME_NONE;
	}
	
	// Update is called once per frame
	void Update () {
	}

    // 전달받은 상태로 게임의 상태 적용
    public void SetGameState(GAME_STATE eGame_State)
    {
        m_eGame_State = eGame_State;

        if (m_eGame_State == GAME_STATE.E_GAME_OVER)
        {
            PangMNG.I.StartCoroutine("GameOverBoom");

        }
    }

    // 게임 일시정지 상태 적용
    public void OnOffGamePause()
    {
        if (m_eGame_State != GAME_STATE.E_GAME_PAUSE)
        {
            m_eBeforeGame_State = m_eGame_State;
            m_eGame_State = GAME_STATE.E_GAME_PAUSE;
        }
        else
        {
            m_eGame_State = m_eBeforeGame_State;
            m_eBeforeGame_State = GAME_STATE.E_GAME_NONE;
        }
    }
}
