using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour
{

    Transform m_cStorePos;

    Vector3 m_stStorePos;

    UICamera m_csUICamera;

    bool m_bStoreState;

    // Use this for initialization
    void Start()
    {
        m_cStorePos = transform;
        m_csUICamera = GameObject.Find("UI Root (2D)").transform.FindChild("Camera").GetComponent<UICamera>();

        m_stStorePos = new Vector3(800.0f, 0.0f, 0.0f);

        m_cStorePos.localPosition = m_stStorePos;

        m_bStoreState = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnOffStore()
    {
        m_bStoreState = !m_bStoreState;

        if (m_bStoreState == true)
        {
            m_stStorePos.x = 0.0f;
            m_cStorePos.localPosition = m_stStorePos;
            m_csUICamera.enabled = false;
        }
        else
        {
            m_stStorePos.x = 800.0f;
            m_cStorePos.localPosition = m_stStorePos;
            m_csUICamera.enabled = true;
        }
    }
}
