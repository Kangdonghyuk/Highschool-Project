using UnityEngine;
using System.Collections;

public class ItemMng : MonoBehaviour {

    private static ItemMng m_Instance = null;
    public static ItemMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(ItemMng)) as ItemMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HFBItemMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    public Transform m_cPreCardAllTurn;
    public Transform m_cPreCardRanClear;

    public UILabel m_csCardAllTurnUILabel;
    public UILabel m_csCardRanClearUILabel;

    bool m_bCardRandomClearCoolState;

    int m_nCardAllTurnNum;
    int m_nCardRandomClearNum;

	// Use this for initialization
	void Start () {
        m_bCardRandomClearCoolState = false;

        m_nCardAllTurnNum = 1;
        m_nCardRandomClearNum = 1;

        m_csCardAllTurnUILabel.text = m_nCardAllTurnNum.ToString();
        m_csCardRanClearUILabel.text = m_nCardRandomClearNum.ToString();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ICardAllTurn()
    {
        if (m_nCardAllTurnNum > 0)
        {
            if (CardMng.I.m_bStartState == false && CardMng.I.m_bICardAllTurnState == false)
            {
                CardMng.I.ICardAllTurn();
                SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUNE_OBER);
                m_nCardAllTurnNum -= 1;

                m_csCardAllTurnUILabel.text = m_nCardAllTurnNum.ToString();
            }
        }
    }

    public void ICardRandomClear()
    {
        if (m_nCardRandomClearNum > 0)
        {
            if (m_bCardRandomClearCoolState == false)
            {
                if (CardMng.I.m_bStartState == false && CardMng.I.m_bICardRandomClearState == false && CardMng.I.m_nCardLiveNum > 0)
                {
                    CardMng.I.ICardRandomClear();
                    SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_ASS);
                    m_nCardRandomClearNum -= 1;
                    m_bCardRandomClearCoolState = true;

                    m_csCardRanClearUILabel.text = m_nCardRandomClearNum.ToString();

                    StartCoroutine("CardRandomClearCool");
                }
            }
        }
    }

    IEnumerator CardRandomClearCool()
    {
        yield return new WaitForSeconds(1.0f);

        m_bCardRandomClearCoolState = false;

        StopCoroutine("CardRandomClearCool");
    }

    public void CreateItem(Vector3 stCreateItemPos)
    {
        int nRandomItemCode = Random.Range(0, 2);

        if (nRandomItemCode == 0)
        {
            Debug.Log("0");
            Transform _TempTm = null;
            _TempTm = (Transform)Instantiate(m_cPreCardAllTurn, stCreateItemPos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            Debug.Log("1");
            _TempTm.parent = transform;
            Debug.Log("2");
        }
        else
        {
            Debug.Log("0");
            Transform _TempTm = null;
            _TempTm = (Transform)Instantiate(m_cPreCardRanClear, stCreateItemPos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
            Debug.Log("1");
            _TempTm.parent = transform;
            Debug.Log("2");
        }
    }

    public void AddAllTurnItem()
    {
        m_nCardAllTurnNum += 1;
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PICKUP);
        m_csCardAllTurnUILabel.text = m_nCardAllTurnNum.ToString();
    }

    public void AddRanClearItem()
    {
        m_nCardRandomClearNum += 1;
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PICKUP);
        m_csCardRanClearUILabel.text = m_nCardRandomClearNum.ToString();
    }
}
