using UnityEngine;
using System.Collections;

public class TutorialCardType : MonoBehaviour {

    UISprite m_csUISprite;
    public string Te;

    Vector3 m_stCardRotation;

    int m_nCardIndex;
    public int m_nCardType;

    bool m_bCardTurnState;
    public bool m_bCardTurningState;
    public bool m_bCardLiveState;

	// Use this for initialization
	void Awake () {
        m_csUISprite = transform.GetChild(0).GetComponent<UISprite>();
	}

    void Start()
    {
        m_stCardRotation = new Vector3(0.0f,1.0f,0.0f);

        m_bCardTurnState = false;
        m_bCardTurningState = false;
        m_bCardLiveState = true;
    }

    public void Init(int nCardIndex)
    {
        m_nCardIndex = nCardIndex;
    }
	
	// Update is called once per frame
	void Update () {
        //CardTurn();

        Te = m_csUISprite.spriteName;
	}

    public void SetType(int nCardType)
    {
        m_nCardType = nCardType;

        m_csUISprite.spriteName = CardTypeMng.I.GetCardSpriteName(m_nCardType);
    }

    public void Turn()
    {
        m_bCardTurnState = !m_bCardTurnState;
        m_bCardTurningState = true;

        StartCoroutine("CardTurn");
    }

    public void Turn2()
    {
        m_bCardTurnState = !m_bCardTurnState;
        m_bCardTurningState = true;

        StartCoroutine("CardTurn2");
    }

    IEnumerator CardTurn()
    {
        int nRotationY = 0;

        while (nRotationY < 90)
        {
            nRotationY += 10;

            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + 10.0f, 0);

            yield return null;
        }

        if (m_bCardTurnState == true)
        {
            m_csUISprite.spriteName = CardTypeMng.I.GetCardBackSpriteName();
        }
        else
        {
            m_csUISprite.spriteName = CardTypeMng.I.GetCardSpriteName(m_nCardType);
        }


        while (nRotationY > 0)
        {
            nRotationY -= 10;

            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y - 10.0f, 0);

            yield return null;
        }

        m_bCardTurningState = false;
        if (m_bCardTurnState == false)
        {
            TutorialCardMng.I.CardTwoCheck();
        }
    }

    IEnumerator CardTurn2()
    {
        int nRotationY = 0;

        while (nRotationY < 90)
        {
            nRotationY += 10;

            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + 10.0f, 0);

            m_bCardTurningState = false;
            yield return null;
        }

        if (m_bCardTurnState == true)
        {
            m_csUISprite.spriteName = CardTypeMng.I.GetCardBackSpriteName();
        }
        else
        {
            m_csUISprite.spriteName = CardTypeMng.I.GetCardSpriteName(m_nCardType);
        }

        while (nRotationY > 0)
        {
            nRotationY -= 10;

            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y - 10.0f, 0);

            m_bCardTurningState = false;
            yield return null;
        }
    }

    public void Clear()
    {
        //m_csUISprite.enabled = false;
        m_bCardLiveState = false;

        //Debug.Log(m_csUISprite.spriteName);
    }

    public void Reset()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);

        m_bCardLiveState = true;
        //m_csUISprite.enabled = true;
        m_bCardTurnState = false;
    }
}
