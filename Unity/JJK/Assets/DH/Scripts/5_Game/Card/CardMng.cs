using UnityEngine;
using System.Collections;

public class CARD
{
    public GameObject m_cCardGam;

    public CardType m_csCardType;

    public int m_nCardIndex;
    public int m_nCardType;

    public bool m_bCardChoiceState;
    public bool m_bCardClearState;

    public bool m_bCardLiveState;
    public bool m_bCardTurnState;


    public void Init(GameObject cCardGam, int nCardIndex)
    {
        m_cCardGam = cCardGam;
        m_csCardType = m_cCardGam.GetComponent<CardType>();

        m_nCardIndex = nCardIndex;
        m_nCardType = CardTypeMng.I.GetCardType(m_nCardIndex);

        m_bCardChoiceState = false;
        m_bCardClearState = false;

        m_bCardTurnState = false;

        m_csCardType.Init(m_nCardIndex);
    }

    public void SetType()
    {
        m_nCardType = CardTypeMng.I.GetCardType(m_nCardIndex);
        m_bCardTurnState = false;

        m_csCardType.SetType(m_nCardType);
    }

    public void Choice()
    {
        m_bCardChoiceState = true;
    }

    public void NChoice()
    {
        m_bCardChoiceState = false;
    }

    public void Reset()
    {
        m_csCardType.Reset();
        m_bCardClearState = false;
        m_bCardTurnState = false;
    }

    public void Turn()
    {
        m_bCardTurnState = !m_bCardTurnState;
        m_csCardType.Turn();
    }

    public void Turn2()
    {
        m_bCardTurnState = !m_bCardTurnState;
        m_csCardType.Turn2();
    }

    public void Clear()
    {
        m_bCardClearState = true;
    }

    public void NClear()
    {
        m_bCardClearState = false;
    }
};


public class CardMng : MonoBehaviour {

    private static CardMng m_Instance = null;
    public static CardMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(CardMng)) as CardMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HFBCardMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    public CARD[] m_cCard;

    public UISprite m_csJackUISprite;

    int m_nCardNum;
    public int m_nCardLiveNum;
    int m_nUserCardNum;

    int m_nCardJackJaKoongNum;

    int m_nTurnNum;
    int m_nTurnSucNum;

    int m_nCardAllClearNum;

    bool m_bTurnState;

    public bool m_bStartState;
    public bool m_bICardRandomClearState;
    public bool m_bICardAllTurnState;
    public bool m_bTouchAbleState;

    
	// Use this for initialization
	void Start () {

        m_nCardNum = transform.GetChildCount();
        m_nUserCardNum = 0;
        m_nCardLiveNum = 2;
        m_nTurnNum = 0;
        m_nTurnSucNum = 0;
        m_nCardAllClearNum = 0;

        m_nCardJackJaKoongNum = 0;

        m_csJackUISprite = transform.parent.FindChild("Jack").GetComponent<UISprite>();

        CardTypeMng.I.SetMatrixCR(m_nCardLiveNum);

        m_cCard = new CARD[m_nCardNum];

        for (int i = 0; i < m_nCardNum; i++)
        {
            m_cCard[i] = new CARD();
            m_cCard[i].Init(transform.GetChild(i).gameObject, i);
            m_cCard[i].SetType();
        }

        m_bTurnState = false;
        m_bStartState = true;

        m_bICardRandomClearState = false;
        m_bICardAllTurnState = false;
        m_bTouchAbleState = true;

        m_csJackUISprite.spriteName = "combo_0";

        StartCoroutine("CardAllTurn");

	}

    IEnumerator CardAllTurn()
    {
        m_bStartState = true;

        yield return new WaitForSeconds(m_nCardLiveNum * 0.5f);

        for (int i = 0; i < m_nCardNum; i++)
        {
            if(m_cCard[i].m_nCardType != -1)
                m_cCard[i].Turn();
        }

        m_bStartState = false;

        StopCoroutine("CardAllTurn");
    }

    IEnumerator ItemCardAllTurn()
    {
        m_bTouchAbleState = false;

        StartCoroutine("TouchCool");

        Debug.Log("ALLTURN");
        m_bICardAllTurnState = true;
        int nTCardIndex = -1;

        for (int i = 0; i < m_nCardNum; i++)
        {
            if (m_cCard[i].m_bCardClearState == false && m_cCard[i].m_nCardType != -1)
            {
                if (m_cCard[i].m_bCardTurnState == true)
                {
                    Debug.Log("1");
                    m_cCard[i].Turn2();
                }
                else
                {
                    Debug.Log("2");
                    nTCardIndex = i;
                }
            }
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < m_nCardNum; i++)
        {
            if (m_cCard[i].m_bCardClearState == false && i != nTCardIndex && m_cCard[i].m_nCardType != -1)
            {
                m_cCard[i].Turn2();
            }
        }

        m_bICardAllTurnState = false;

        StopCoroutine("ItemCardAllTurn");
    }

    IEnumerator ItemCardRandomClear()
    {
        m_bTouchAbleState = false;

        StartCoroutine("TouchCool");

            m_bICardRandomClearState = true;

            int nRandomCardType = -1;
            int nRandomCardIndex1 = -1;
            int nRandomCardIndex2 = -1;
            while (true)
            {
                nRandomCardIndex1 = Random.Range(0, m_nCardNum);
                if (m_cCard[nRandomCardIndex1].m_bCardClearState == false && m_cCard[nRandomCardIndex1].m_nCardType != -1)
                {
                    nRandomCardType = m_cCard[nRandomCardIndex1].m_nCardType;
                    break;
                }
            }
            for (nRandomCardIndex2 = 0; nRandomCardIndex2 < m_nCardNum; nRandomCardIndex2++)
            {
                if (m_cCard[nRandomCardIndex2].m_nCardType == nRandomCardType && nRandomCardIndex1 != nRandomCardIndex2)
                {
                    break;
                }
            }

            m_cCard[nRandomCardIndex1].Choice();
            m_cCard[nRandomCardIndex1].Turn();

            while (true)
            {
                if (m_cCard[nRandomCardIndex1].m_csCardType.m_bCardTurningState == false)
                {
                    m_cCard[nRandomCardIndex2].Choice();
                    m_cCard[nRandomCardIndex2].Turn();
                    //m_nCardTurnNum = 2;
                    break;
                }

                yield return null;
            }

        m_bICardRandomClearState = false;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Escape))
        {
            ItemMng.I.ICardAllTurn();
            //ICardAllTurn();
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Menu))
        {
            ItemMng.I.ICardRandomClear();
            //ICardRandomClear();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Time.timeScale = 0;
        }
    }

    public void ICardAllTurn()
    {
        StartCoroutine("ItemCardAllTurn");
    }

    public void ICardRandomClear()
    {
        StartCoroutine("ItemCardRandomClear");
    }

    public void CardTwoCheck()
    {
        m_nTurnNum += 1;
        if (m_nTurnNum == 2)
        {
            CardTwoTurnSuc();
            m_nTurnNum = 0;
        }
    }

    public void CardTwoTurnSuc()
    {
        int nCardType1 = -2;
        int nCardType2 = -3;
        int nCardIndex1 = 0;
        int nCardIndex2 = 0;

        for (int i = 0; i < m_nCardNum; i++)
        {
            if (m_cCard[i].m_bCardChoiceState == true && m_cCard[i].m_bCardClearState == false &&
                m_cCard[i].m_csCardType.m_bCardTurningState == false)
            {
                if (nCardType1 == -2)
                {
                    nCardType1 = m_cCard[i].m_nCardType;
                    nCardIndex1 = i;
                }
                else if (nCardType2 == -3)
                {
                    nCardType2 = m_cCard[i].m_nCardType;
                    nCardIndex2 = i;
                }
            }
        }

        Debug.Log(nCardType1 + " : " + nCardType2);

        if (nCardType1 == nCardType2)
        {
            SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_CLEAR);

            Score.I.AddScore();

            m_cCard[nCardIndex1].Clear();
            m_cCard[nCardIndex2].Clear();

            m_nCardLiveNum -= 1;

            if (m_nCardLiveNum == 0)
            {
                m_nCardAllClearNum += 1;
                StartCoroutine("RReset");
            }

            if (Random.Range(0, 10) == 7)
            {
                ItemMng.I.CreateItem(m_cCard[nCardIndex1].m_cCardGam.transform.position);
            }

            Debug.Log("SUCC");
        }
        else
        {
            SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_FAIL);

            m_cCard[nCardIndex1].Turn();
            m_cCard[nCardIndex1].NChoice();

            m_cCard[nCardIndex2].Turn();
            m_cCard[nCardIndex2].NChoice();
        }
    }

    public void CardChoice(GameObject cCardGam)
    {
        if (m_bTouchAbleState == true)
        {
            for (int i = 0; i < m_nCardNum; i++)
            {
                if (m_cCard[i].m_cCardGam == cCardGam)
                {
                    if (m_cCard[i].m_bCardClearState == false &&
                        m_cCard[i].m_csCardType.m_bCardTurningState == false && m_cCard[i].m_nCardType != -1)
                    {
                        if (m_cCard[i].m_bCardChoiceState == false)
                        {
                            m_cCard[i].Choice();
                            m_cCard[i].Turn();

                            break;
                        }
                    }
                }
            }
        }
    }

    public void CardChoiceSuccess()
    {
        m_bTurnState = true;
        m_bStartState = true;
    }

    public void Reset()
    {
        m_nUserCardNum = 0;
        m_bTurnState = false;
        m_nTurnNum = 0;
        m_nTurnSucNum = 0;
        m_bStartState = true;

        CardAllTurnTime();
    }


    IEnumerator RReset()
    {
        yield return new WaitForSeconds(1.0f);

        if (m_nCardAllClearNum >= 8)
            m_nCardLiveNum = 6;
        else if (m_nCardAllClearNum >= 6)
            m_nCardLiveNum = 5;
        else if (m_nCardAllClearNum >= 4)
            m_nCardLiveNum = 4;
        else if (m_nCardAllClearNum >= 2)
            m_nCardLiveNum = 3;
        else
            m_nCardLiveNum = 2;

        CardTypeMng.I.SetMatrixCR(m_nCardLiveNum);


        for (int i = 0; i < m_nCardNum; i++)
        {
            m_cCard[i].Reset();
            m_cCard[i].NChoice();
            m_cCard[i].NClear();
            m_cCard[i].SetType();
        }

        m_nCardJackJaKoongNum += 1;

        m_csJackUISprite.spriteName = "combo_" + m_nCardJackJaKoongNum.ToString();
        Debug.Log(m_nCardJackJaKoongNum);

        if (m_nCardJackJaKoongNum == 3)
        {
            m_nCardJackJaKoongNum = 0;
            GameMng.I.Fever();
        }
        else
        {
            CardAllTurnTime();
        }

        m_bStartState = true;

        StopCoroutine("RReset");
    }

    public void JackReset()
    {
        m_nCardJackJaKoongNum = 0;
        m_csJackUISprite.spriteName = "combo_" + m_nCardJackJaKoongNum.ToString();
    }

    public void CardAllTurnTime()
    {
        StartCoroutine("CardAllTurn");
    }

    IEnumerator TouchCool()
    {
        yield return new WaitForSeconds(1.5f);

        m_bTouchAbleState = true;

        StopCoroutine("TouchCool");
    }
}
