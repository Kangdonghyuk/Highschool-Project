using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {
    Transform m_cTransform;
    SphereCollider m_cSphereCollider;
    Rigidbody m_cRigidBody;

    static Vector3 m_stRemovePos = new Vector3(1.0f, 2.0f, 0.0f);
    static Vector3 m_stCreatePos = new Vector3(0.0f, 0.55f, 0.0f);

	// Use this for initialization
	void Start () {

        m_cTransform = GetComponent<Transform>();
        m_cSphereCollider = GetComponent<SphereCollider>();
        m_cRigidBody = GetComponent<Rigidbody>();

        Remove();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Create()
    {
        m_cSphereCollider.enabled = true;
        m_cRigidBody.WakeUp();
        m_stCreatePos.x = Random.Range(-0.45f, 0.45f);

        m_cTransform.position = m_stCreatePos;
    }

    public void Remove()
    {
        m_cSphereCollider.enabled = false;
        m_cRigidBody.Sleep();
        m_cTransform.position = m_stRemovePos;
    }
}
