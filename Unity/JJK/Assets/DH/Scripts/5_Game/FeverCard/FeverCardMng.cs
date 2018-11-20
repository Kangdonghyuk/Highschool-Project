using UnityEngine;
using System.Collections;

public class FEVERCARD
{
    public GameObject m_cFeverCardGam;

    public FeverCardType m_csFeverCardType;

    public int m_nFeverCardType;

    public bool m_bFeverCardChoiceState;
    public bool m_bFeverCardClearState;

    public void Init(GameObject cFeverCardGam)
    {
        m_cFeverCardGam = cFeverCardGam;
        m_csFeverCardType = m_cFeverCardGam.GetComponent<FeverCardType>();

        m_nFeverCardType = m_csFeverCardType.m_nFeverCardType;
        m_bFeverCardChoiceState = false;
        m_bFeverCardClearState = false;
    }

    public void Choice()
    {
        m_bFeverCardChoiceState = true;
    }

    public void NChoice()
    {
        m_bFeverCardChoiceState = false;
    }

    public void Turn()
    {
        m_csFeverCardType.CardTurn();
    }

    public void Reset()
    {
        m_csFeverCardType.Reset();
        m_bFeverCardClearState = false;
    }

    public void Clear()
    {
        m_bFeverCardClearState = true;
    }

    public void NClear()
    {
        m_bFeverCardClearState = false;
    }
};

public class FeverCardMng : MonoBehaviour {

    private static FeverCardMng m_Instance = null;
    public static FeverCardMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(FeverCardMng)) as FeverCardMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HFBFeverCardMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    public FEVERCARD[] m_cFeverCard;

    int m_nFeverCardNum;
    int m_nFeverCardLiveNum;
    int m_nFeverUserCardNum;

    int m_nFeverTurnNum;
    int m_nFeverTurnSucNum;

    bool m_bFeverTurnState;
    public bool m_bFeverStartState;
    public bool m_bTouchAbleState;

	// Use this for initialization
	void Start () {

        m_nFeverCardNum = transform.GetChildCount();
        m_nFeverUserCardNum = 0;
        m_nFeverTurnNum = 0;
        m_nFeverTurnSucNum = 0;
        m_nFeverCardLiveNum = 6;

        m_cFeverCard = new FEVERCARD[m_nFeverCardNum];

        for (int i = 0; i < m_nFeverCardNum; i++)
        {
            m_cFeverCard[i] = new FEVERCARD();
            m_cFeverCard[i].Init(transform.GetChild(i).gameObject);
        }

        m_bFeverTurnState = false;
        m_bFeverStartState = true;
        m_bTouchAbleState = true;

        StartCoroutine("FeverCardAllTurn");
	
	}

    IEnumerator FeverCardAllTurn()
    {
        m_bFeverStartState = true;

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < m_nFeverCardNum; i++)
        {
            m_cFeverCard[i].Turn();
            //m_nFeverTurnNum += 1;
        }

        m_bFeverStartState = false;

        StopCoroutine("FeverCardAllTurn");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            m_bTouchAbleState = true;
        }
	}

    public void Reset()
    {
        m_nFeverUserCardNum = 0;
        m_bFeverTurnState = false;
        m_nFeverTurnNum = 0;
        m_nFeverTurnSucNum = 0;
        m_bFeverStartState = false;
        m_nFeverCardLiveNum = 6;

        for (int i = 0; i < m_nFeverCardNum; i++)
        {
            m_cFeverCard[i].Reset();
             m_cFeverCard[i].NChoice();
             if (m_cFeverCard[i].m_nFeverCardType == 0)
             {
                 m_nFeverUserCardNum += 1;
             }
        }

        StartCoroutine("FeverCardAllTurn");
    }

    public void FeverCardTwoCheck()
    {
        m_nFeverTurnNum += 1;
        if (m_nFeverTurnNum == 2)
        {
            FeverCardTwoTurnSuc();
            m_nFeverTurnNum = 0;
        }
    }

    void FeverCardTwoTurnSuc()
    {
        Debug.Log("FeverCardTwoTurnSuc");

        int nFeverCardType1 = -2;
        int nFeverCardType2 = -3;
        int nFeverCardIndex1 = 0;
        int nFeverCardIndex2 = 0;

        for (int i = 0; i < m_nFeverCardNum; i++)
        {
            if (m_cFeverCard[i].m_bFeverCardChoiceState == true && m_cFeverCard[i].m_bFeverCardClearState == false &&
                m_cFeverCard[i].m_csFeverCardType.m_bCardTurningState == false)
            {
                if (nFeverCardType1 == -2)
                {
                    nFeverCardType1 = m_cFeverCard[i].m_nFeverCardType;
                    nFeverCardIndex1 = i;
                }
                else if (nFeverCardType2 == -3)
                {
                    nFeverCardType2 = m_cFeverCard[i].m_nFeverCardType;
                    nFeverCardIndex2 = i;
                }
            }
        }

        Debug.Log(nFeverCardType1 + " : " + nFeverCardType2);

        if (nFeverCardType1 == nFeverCardType2)
        {
            SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_CLEAR);
            Score.I.AddScore();

            m_cFeverCard[nFeverCardIndex1].Clear();
            m_cFeverCard[nFeverCardIndex2].Clear();
            Debug.Log("SUCCESS");
            m_nFeverCardLiveNum -= 1;

            if (m_nFeverCardLiveNum == 0)
            {
                GameMng.I.NFever();
            }

            TimeBar.I.AddTime(2.0f);
        }
        else
        {
            SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_FAIL);

            Debug.Log("FAIL");
            m_bTouchAbleState = false;
            m_cFeverCard[nFeverCardIndex1].Turn();
            m_cFeverCard[nFeverCardIndex1].NChoice();

            m_cFeverCard[nFeverCardIndex2].Turn();
            m_cFeverCard[nFeverCardIndex2].NChoice();

            TimeBar.I.AddTime(-1.0f);
        }
    }

    public void FeverCardChoice(GameObject cFeverCardGam)
    {
        //if (m_bTouchAbleState == true)
        {
            for (int i = 0; i < m_nFeverCardNum; i++)
            {
                if (m_cFeverCard[i].m_cFeverCardGam == cFeverCardGam && m_cFeverCard[i].m_bFeverCardChoiceState == false &&
                    m_cFeverCard[i].m_bFeverCardClearState == false && m_cFeverCard[i].m_csFeverCardType.m_bCardTurningState == false)
                {
                    m_cFeverCard[i].Choice();
                    m_cFeverCard[i].Turn();
                    /*if (m_cFeverCard[i].m_nFeverCardType == 0)
                    {
                        m_nFeverCardLiveNum += 1;

                        if (m_nFeverCardLiveNum == m_nFeverUserCardNum)
                        {
                            Debug.Log("HULL");
                            FeverCardChoiceSuccess();
                        }
                    }
                    else
                    {
                        FeverCardChoiceSuccess();
                    }*/

                    break;
                }
            }
        }
    }

    public void FeverCardChoiceSuccess()
    {
        m_bFeverStartState = true;
        m_bFeverTurnState = true;
    }

    public void FeverCardAllTurnSuccess()
    {
        /*m_nFeverTurnSucNum += 1;
        //Debug.Log(m_nFeverTurnNum + " : " + m_nFeverTurnSucNum);
        if (m_nFeverTurnNum == m_nFeverTurnSucNum)
        {
            if (m_bFeverTurnState == true)
            {
                if (m_nFeverCardLiveNum == m_nFeverUserCardNum)
                {
                    Debug.Log("SUCCESS");
                }
                else if (m_nFeverCardLiveNum < m_nFeverUserCardNum)
                {
                    Debug.Log("FAIL");
                }

                m_nFeverCardLiveNum = 0;

                for (int i = 0; i < m_nFeverCardNum; i++)
                {
                    if (m_cFeverCard[i].m_bFeverCardChoiceState == true)
                    {
                        m_cFeverCard[i].NChoice();
                    }
                }

                m_nFeverTurnSucNum = 0;
                m_nFeverTurnNum = 0;

                StartCoroutine("NFeverCool");

                m_bFeverTurnState = false;
            }
        }*/
    }

    IEnumerator NFeverCool()
    {
        yield return new WaitForSeconds(0.5f);

        GameMng.I.NFever();

        StopCoroutine("NFeverCool");
    }
}
