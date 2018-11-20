using UnityEngine;
using System.Collections;

public class PangBoom : MonoBehaviour {

    Transform m_cTransform; // 气藕 Transform  
    SphereCollider m_cCollider; // 气藕 Collider
    Rigidbody m_cRigidbody; // 气藕 Rigidbody

    ////////////////////
    static Vector3 m_stRemovePos = new Vector3(0.5f, 2.0f, 0.0f); // 气藕 扁夯 谅钎
    static Vector3 m_stCreatePos = new Vector3(0.0f, 0.55f, 0.0f); // 气藕 积己 谅钎
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

    // 气藕 瘤快扁
    public void Remove()
    {
        m_cCollider.enabled = false;
        m_cRigidbody.Sleep();
        m_cTransform.position = m_stRemovePos;
    }

    // 气藕 积己
    public void Create()
    {
        m_cCollider.enabled = true;
        m_cRigidbody.WakeUp();

        m_stCreatePos.x = Random.Range(-0.45f,0.45f);
        m_cTransform.position = m_stCreatePos;
    }
}
