using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {
    tk2dSprite m_cstk2dSprite;

    Transform m_cTransform;
    SphereCollider m_cSphereCollider;
    Rigidbody m_cRigidBody;

    Color m_cColor;

    static WaitForSeconds m_cWaitForSeconds = new WaitForSeconds(5.0f);

    static Vector3 m_stRemovePos = new Vector3(1.5f, 2.0f, 0.0f);
    static Vector3 m_stCreatePos = new Vector3(0.0f, 0.55f, 0.0f);

    float m_fPasent;

    int m_nMaxHP;
    int m_nHP;
    int m_nHPCount;

	// Use this for initialization
	void Start () {
        m_cstk2dSprite = GetComponent<tk2dSprite>();

        m_cTransform = GetComponent<Transform>();
        m_cSphereCollider = GetComponent<SphereCollider>();
        m_cRigidBody = GetComponent<Rigidbody>();

        m_cColor = new Color(1.0f, 1.0f, 1.0f);

        m_nMaxHP = 20;
        m_nHP = 0;
        m_nHPCount = 0;

        m_fPasent = 2.0f / m_nMaxHP;

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

        m_cColor.r = 1.0f;
        m_cColor.g = 1.0f;
        m_cColor.b = 1.0f;
        m_cstk2dSprite.color = m_cColor;

        m_nHP = m_nMaxHP;
        m_nHPCount = 0;

        StartCoroutine("AutoAttack");
    }

    public void Remove()
    {
        m_cSphereCollider.enabled = false;
        m_cRigidBody.Sleep();
        m_cTransform.position = m_stRemovePos;

        m_nHP = 0;

        StopCoroutine("AutoAttack");
    }

    public void Heat(int nDamage)
    {
        m_nHP -= nDamage;

        if (m_nHPCount == 0)
        {
            m_cColor.g -= (m_fPasent * nDamage);
            m_cColor.b -= (m_fPasent * nDamage);

            if (m_cColor.g <= 0.1f)
            {
                m_nHPCount = 1;
            }

            m_cstk2dSprite.color = m_cColor;
        }
        else if (m_nHPCount == 1)
        {
            m_cColor.r -= (m_fPasent * nDamage);

            m_cstk2dSprite.color = m_cColor;
        }

        if (m_nHP <= 0)
        {
            m_nHP = 0;

            EnemyMNG.I.RemoveMob(gameObject);
        }
    }

    IEnumerator AutoAttack()
    {
        while (true)
        {
            yield return m_cWaitForSeconds;

            EnemyMNG.I.CreateRock();
        }
    }
}
