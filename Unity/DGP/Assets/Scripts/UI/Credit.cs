using UnityEngine;
using System.Collections;

public class Credit : MonoBehaviour
{

    Transform m_cCreditPos;

    Vector3 m_stCreditPos;

    UICamera m_csUICamera;

    bool m_bCreditState;

    // Use this for initialization
    void Start()
    {
        m_cCreditPos = transform;
        m_csUICamera = GameObject.Find("UI Root (2D)").transform.FindChild("Camera").GetComponent<UICamera>();

        m_stCreditPos = new Vector3(800.0f, 0.0f, 0.0f);

        m_cCreditPos.localPosition = m_stCreditPos;

        m_bCreditState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bCreditState == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                OnOffCredit();
            }
        }
    }

    public void OnOffCredit()
    {
        m_bCreditState = !m_bCreditState;

        if (m_bCreditState == true)
        {
            m_stCreditPos.x = 0.0f;
            m_cCreditPos.localPosition = m_stCreditPos;
            m_csUICamera.enabled = false;
        }
        else
        {
            m_stCreditPos.x = 800.0f;
            m_cCreditPos.localPosition = m_stCreditPos;
            m_csUICamera.enabled = true;
        }
    }
}
