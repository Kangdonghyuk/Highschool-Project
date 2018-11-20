using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    Transform m_cTransform; // �ڽ��� Transform

    Vector3 m_stPausePos; // �ڽ��� Transform

    UICamera m_csUICamera;

    bool m_bShowState; // �Ͻ����� ����

	// Use this for initialization
	void Start () {
        m_cTransform = GetComponent<Transform>();
        m_csUICamera = GameObject.Find("UI Root (2D)").transform.FindChild("Camera").GetComponent<UICamera>();

        m_stPausePos = new Vector3(0.0f, 0.0f, 0.0f);

        m_bShowState = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // �Ͻ����� ���� �� ����
    public void OnOffPause()
    {
        m_bShowState = !m_bShowState;
        if (m_bShowState == true)
        {
            m_csUICamera.enabled = false;
           Time.timeScale = 0.0f;
            m_stPausePos.y = 0.0f;
            m_cTransform.localPosition = m_stPausePos;
        }
        else
        {
            m_csUICamera.enabled = true;
           Time.timeScale = 1.0f;
            m_stPausePos.y = 900.0f;
            m_cTransform.localPosition = m_stPausePos;
        }
    }
}
