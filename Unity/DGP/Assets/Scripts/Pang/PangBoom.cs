using UnityEngine;
using System.Collections;

public class PangBoom : MonoBehaviour {

    Transform m_cTransform; // ��ź Transform  
    SphereCollider m_cCollider; // ��ź Collider
    Rigidbody m_cRigidbody; // ��ź Rigidbody

    ////////////////////
    static Vector3 m_stRemovePos = new Vector3(0.5f, 2.0f, 0.0f); // ��ź �⺻ ��ǥ
    static Vector3 m_stCreatePos = new Vector3(0.0f, 0.55f, 0.0f); // ��ź ���� ��ǥ
    ////////////////////

	// Use this for initialization
	void Start () {
        m_cTransform = GetComponent<Transform>();
        m_cCollider = GetComponent<SphereCollider>();
        m_cRigidbody = GetComponent<Rigidbody>();

        Remove();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // ��ź �����
    public void Remove()
    {
        m_cCollider.enabled = false;
        m_cRigidbody.Sleep();
        m_cTransform.position = m_stRemovePos;
    }

    // ��ź ����
    public void Create()
    {
        m_cCollider.enabled = true;
        m_cRigidbody.WakeUp();

        m_stCreatePos.x = Random.Range(-0.45f,0.45f);
        m_cTransform.position = m_stCreatePos;
    }
}
