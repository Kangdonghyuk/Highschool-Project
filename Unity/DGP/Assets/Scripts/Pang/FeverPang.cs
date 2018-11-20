using UnityEngine;
using System.Collections;

public class FeverPang : MonoBehaviour {

    Transform m_cTransform;

    SphereCollider m_cCollider;
    Rigidbody m_cRigidbody;

    Vector3 m_stRemovePos = new Vector3(4.0f, 2.0f, 0.0f);
    Vector3 m_stGetPos;
    Vector3 m_stNormalPos = new Vector3(0.0f, 0.55f, 0.0f);
    Vector3 m_stVelocity = new Vector3(0.0f, 0.0f, 0.0f);

    Vector3 scrSpace;
    Vector3 offset;
    Vector3 input;
    Vector3 curScreenSpace;
    Vector3 curPosition;

	// Use this for initialization
	void Start () {
        m_cTransform = transform;

        m_cCollider = GetComponent<SphereCollider>();
        m_cRigidbody = GetComponent<Rigidbody>();

        OffFever();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Down()
    {
        StartCoroutine("OnMouseDown");
    }
    public void Up()
    {
        StopCoroutine("OnMouseDown");
    }

    public void OnFever()
    {
        m_cCollider.enabled = true;
        m_cRigidbody.WakeUp();
        m_cRigidbody.velocity = m_stVelocity;
        m_cTransform.position = m_stNormalPos;
        m_cTransform.renderer.enabled = true;
    }

    public void OffFever()
    {
        m_cCollider.enabled = false;
        m_cRigidbody.Sleep();
        m_cTransform.position = m_stRemovePos;
        m_cTransform.renderer.enabled = false;
    }

    IEnumerator OnMouseDown()
    {
        scrSpace = Camera.main.WorldToScreenPoint(m_cTransform.position);

        input.x = Input.mousePosition.x;
        input.y = Input.mousePosition.y;
        input.z = scrSpace.z;

        offset = m_cTransform.position - Camera.main.ScreenToWorldPoint(input);

        while (true)
        {
            /* input = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             input.z = m_fLateZ;
             m_cTransform.position = input;*/

            input.x = Input.mousePosition.x;
            input.y = Input.mousePosition.y;
            input.z = scrSpace.z;

            curScreenSpace = input;
            curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            if (Mathf.Abs(curPosition.x) >= 0.55f || curPosition.y <= -0.75f || curPosition.y >= 0.65f)
            {
                Up();
                break;
            }
            else
            {
                m_cTransform.position = curPosition;
            }

            yield return null;
        }
    }
}
