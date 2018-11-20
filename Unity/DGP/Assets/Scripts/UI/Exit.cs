using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{

    Transform m_cExitPos;

    Vector3 m_stExitPos;

    UICamera m_csUICamera;

    bool m_bExitState;

    // Use this for initialization
    void Start()
    {
        m_cExitPos = transform;
        m_csUICamera = GameObject.Find("UI Root (2D)").transform.FindChild("Camera").GetComponent<UICamera>();

        m_stExitPos = new Vector3(800.0f, 0.0f, 0.0f);

        m_cExitPos.localPosition = m_stExitPos;

        m_bExitState = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnOffExit()
    {
        m_bExitState = !m_bExitState;

        if (m_bExitState == true)
        {
            m_stExitPos.x = 0.0f;
            m_cExitPos.localPosition = m_stExitPos;
            m_csUICamera.enabled = false;
        }
        else
        {
            m_stExitPos.x = 800.0f;
            m_cExitPos.localPosition = m_stExitPos;
            m_csUICamera.enabled = true;
        }
    }
}
