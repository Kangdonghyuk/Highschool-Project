using UnityEngine;
using System.Collections;

public class PangEfectMNG : MonoBehaviour {
    Transform m_cTransform; // �ڽ��� Transform

    PangEfect[] m_csPangEfect; // ����Ʈ���� PangEfect ��ũ��Ʈ

    int m_nPangEfectMaxNum; // ����Ʈ�� �ִ� ����

    /*
    private static PangEfectMNG m_Instance = null;
    public static PangEfectMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(PangEfectMNG)) as PangEfectMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get PangEfectMNG Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }
    */

	// Use this for initialization
	void Start () {
        m_cTransform = GetComponent<Transform>();

        m_nPangEfectMaxNum = m_cTransform.childCount;

        m_csPangEfect = new PangEfect[m_nPangEfectMaxNum];

        int i = 0;
        while (i < m_nPangEfectMaxNum)
        {
            m_csPangEfect[i] = m_cTransform.GetChild(i).GetComponent<PangEfect>();
            i += 1;
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    // ��Ȱ��ȭ������ ����Ʈ�� ������ǥ�� ���
    public void Create(Vector3 stPos)
    {
        int i = 0;
        while (i < m_nPangEfectMaxNum)
        {
            if (m_csPangEfect[i].m_bPangEfectState == false)
            {
                m_csPangEfect[i].Create(stPos);
                return;
            }
            i += 1;
        }
    }
}
