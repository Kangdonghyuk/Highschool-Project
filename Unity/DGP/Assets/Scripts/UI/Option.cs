using UnityEngine;
using System.Collections;

public class Option : MonoBehaviour {

    Transform m_cOptionPos;

    Vector3 m_stOptionPos;

    UICamera m_csUICamera;

    bool m_bOptionState;

	// Use this for initialization
	void Start () {
        m_cOptionPos = transform;
        m_csUICamera = GameObject.Find("UI Root (2D)").transform.FindChild("Camera").GetComponent<UICamera>();

        m_stOptionPos = new Vector3(0.0f,800.0f,0.0f);

        m_cOptionPos.localPosition = m_stOptionPos;

        m_bOptionState = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnOffOption()
    {
        m_bOptionState = !m_bOptionState;

        if (m_bOptionState == true)
        {
            m_stOptionPos.y = 0.0f;
            m_cOptionPos.localPosition = m_stOptionPos;
            m_csUICamera.enabled = false;
        }
        else
        {
            m_stOptionPos.y = 800.0f;
            m_cOptionPos.localPosition = m_stOptionPos;
            m_csUICamera.enabled = true;
        }
    }
}
