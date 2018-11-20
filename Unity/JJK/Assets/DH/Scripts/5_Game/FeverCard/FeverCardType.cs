using UnityEngine;
using System.Collections;

public class FeverCardType : MonoBehaviour {

    UISprite m_csUISprite;

    Vector3 m_stCardRotation;

    public int m_nFeverCardType;

    bool m_bCardTurnState;
    public bool m_bCardTurningState;

	// Use this for initialization
	void Awake () {
        m_csUISprite = transform.GetChild(0).GetComponent<UISprite>();

        m_nFeverCardType = 0;

        if (m_csUISprite.spriteName == "SUN")
            m_nFeverCardType = -1;
	}

    void Start()
    {
        m_stCardRotation = new Vector3(0.0f, 1.0f, 0.0f);

        m_bCardTurnState = false;
        m_bCardTurningState = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CardTurn()
    {
        m_bCardTurnState = !m_bCardTurnState;
        m_bCardTurningState = true;

        StartCoroutine("FeverCardTurn");
    }

    public void Reset()
    {
        m_csUISprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        m_bCardTurnState = false;
        m_bCardTurningState = false;

        m_csUISprite.spriteName = CardTypeMng.I.GetFeverCardSpriteName(m_nFeverCardType);

        transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    IEnumerator FeverCardTurn()
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
            m_csUISprite.spriteName = CardTypeMng.I.GetFeverCardBackSpriteName();
        }
        else
        {
            m_csUISprite.spriteName = CardTypeMng.I.GetFeverCardSpriteName(m_nFeverCardType);
        }

        while (nRotationY > 0)
        {
            nRotationY -= 10;

            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y - 10.0f, 0);

            yield return null;

        }

        m_bCardTurningState = false;

        if (Application.loadedLevelName == "5_Game")
        {
            if (m_bCardTurnState == false)
            {
                FeverCardMng.I.FeverCardTwoCheck();
            }

            FeverCardMng.I.FeverCardAllTurnSuccess();
        }
        else
        {
            if (m_bCardTurnState == false)
            {
                TutorialFeverCardMng.I.FeverCardTwoCheck();
            }

            TutorialFeverCardMng.I.FeverCardAllTurnSuccess();
        }
    }
}
