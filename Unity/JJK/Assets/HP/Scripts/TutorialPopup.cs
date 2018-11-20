using UnityEngine;
using System.Collections;

public class TutorialPopup : MonoBehaviour {
    UISprite m_cSprite = null;

	// Use this for initialization
	void Start () {
        m_cSprite = GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
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
