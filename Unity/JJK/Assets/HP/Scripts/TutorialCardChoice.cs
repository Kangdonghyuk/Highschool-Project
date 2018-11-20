using UnityEngine;
using System.Collections;

public class TutorialCardChoice : MonoBehaviour {

    Ray m_stRay;
    RaycastHit m_stRaycastHit;

    Camera m_cCamera;

	// Use this for initialization
	void Start () {
        m_cCamera = transform.parent.parent.parent.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameMng.I.m_eGameState == GameMng.GAME_STATE.E_GAME_PLAY)
        {
            if (Input.GetMouseButton(0))
            {
                m_stRay = m_cCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(m_stRay, out m_stRaycastHit))
                {
                    if (m_stRaycastHit.transform.tag == "CARD")
                    {
                        if (TutorialCardMng.I.m_bStartState == false)
                        {
                            TutorialCardMng.I.CardChoice(m_stRaycastHit.transform.gameObject);
                        }
                    }
                }
            }
        }
	}
}
