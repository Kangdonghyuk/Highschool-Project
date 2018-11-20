using UnityEngine;
using System.Collections;

public class TutorialMessage : MonoBehaviour {
    UISprite m_cSprite = null;
    int m_nTurn = -1;

	// Use this for initialization
	void Start () {
        m_cSprite = GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_nTurn != Tutorial.I.m_nTurn)
        {
            m_cSprite.spriteName = "Tutorial" + (Tutorial.I.m_nTurn < 10 ? '0' + Tutorial.I.m_nTurn.ToString() : Tutorial.I.m_nTurn.ToString());
            m_cSprite.MakePixelPerfect();
            transform.localScale = new Vector3(320.0f, transform.localScale.y);
            m_nTurn = Tutorial.I.m_nTurn;
        }

        if ((Tutorial.I.m_nTurn == 8 || Tutorial.I.m_nTurn == 12) && Tutorial.I.m_bClear == false)
        {
            m_cSprite.enabled = false;
        }
        else
        {
            m_cSprite.enabled = true;
        }
	}
}
