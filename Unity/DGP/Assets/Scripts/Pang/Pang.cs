using UnityEngine;
using System.Collections;

// ���� �⺻���� ������ ����

public class Pang : MonoBehaviour {
    tk2dSprite m_cstk2dSprite; //tk2dSprite ��ũ��Ʈ ���� ����

    Transform m_cTransform; // �ش� ���� Transform ����
    SphereCollider m_cCollider; // �ش� ���� Collider ����
    Rigidbody m_cRigidbody; // �ش����� Rigidbody ����

    static Vector3 m_stRemovePos = new Vector3(0.0f, 2.0f, 0.0f); // ���� �⺻��ġ(static) ����
    Vector3 m_stGetPos; // �ش� ���� ��ǥ ����

    bool m_bPangState; // �ش� ���� ���� ����(Ȱ��,��Ȱ��)

    public int m_nPangType; // �ش� ���� Ÿ�� ����

   // static int m_nAddName;
    static float m_fCreateNum; // �ε��� ��ǥ�� ���� ������ ����
    float m_fLateZ; // �ش� ���� Z��ǥ ����
    /////////////////////////////////////
    static int[] m_nSpriteId = new int[9]; // �� Ÿ�Դ� SpriteID ����
    /////////////////////////////////////
    static Vector3 m_stVelocity = new Vector3(0.0f, 0.0f, 0.0f); // �ε��� �⺻ ���ӵ� ����
    /////////////////////////////////////
    //static Color m_stPangColor;
    /////////////////////////////////////
    static Vector3 scrSpace;
    Vector3 offset;
    static Vector3 input;
    static Vector3 curScreenSpace;
    static Vector3 curPosition;
    /////////////////////////////////////

	// Use this for initialization
	void Start () {
        m_cstk2dSprite = GetComponent<tk2dSprite>();

        m_cTransform = GetComponent<Transform>();
        m_cCollider = GetComponent<SphereCollider>();
        m_cRigidbody = GetComponent<Rigidbody>();

        m_fCreateNum -= 0.0001f;
        if (m_fCreateNum <= -0.005f)
        {
            m_fCreateNum = 0.0f;
        }
        m_fLateZ = m_fCreateNum;

       // m_cTransform.name = m_nAddName.ToString();
        //m_nAddName += 1;

        int i = 0;
        while (i < 9)
        {
            m_nSpriteId[i] = m_cstk2dSprite.GetSpriteIdByName(i.ToString());
            i += 1;
        }

       /* if (m_stPangColor == null)
        {
            m_stPangColor = new Color(1.0f, 1.0f, 1.0f);
        }*/

        //m_stRemovePos = new Vector3(0.0f, 2.0f, 0.0f);

        m_bPangState = false;

        m_nPangType = 0;

        Remove();
	}
	
	// Update is called once per frame
	void Update () {
        if (m_bPangState == true)
        {
            m_stGetPos = m_cTransform.position;
            if (m_stGetPos.y >= 0.68f || m_stGetPos.y <= -0.77f || Mathf.Abs(m_stGetPos.x) >= 0.57f)
            {
               //PangMNG.I.Up();
              PangMNG.I.Remove(gameObject);;
            }
            /*if (m_stGetPos.y >= 0.65f || m_stGetPos.y <= -0.76f || Mathf.Abs(m_stGetPos.x) >= 0.56f)
            {
                PangMNG.I.Remove(gameObject);
            }*/
        }
	}   

    // ���޹��� ��ǥ�� ���� ����
    public void Create(Vector3 stPos)
    {
        m_cCollider.enabled = true;
        m_cRigidbody.WakeUp();
        m_cRigidbody.velocity = m_stVelocity;
        stPos.z = m_fLateZ;
        m_cTransform.position = stPos;

        if (PangMNG.I.m_bCheckTest == false)
        {
           // if (GameMNG.I.m_eGame_State == GameMNG.GAME_STATE.E_GAME_FEVER)
              //  m_nPangType = Random.Range(0, 2);
            //else
                m_nPangType = Random.Range(0, 9);
                if (KDHManager.I.m_bPangKindSubState == true)
                    m_nPangType = Random.Range(0, 7);
            m_cstk2dSprite.spriteId = m_nSpriteId[m_nPangType];// m_cstk2dSprite.GetSpriteIdByName(m_nPangType.ToString());
            //GetColor();
           // m_cstk2dSprite.color = m_stPangColor;
        }
        else
        {
            m_nPangType = 0;
           // GetColor();
            m_cstk2dSprite.spriteId = m_nSpriteId[m_nPangType];// m_cstk2dSprite.GetSpriteIdByName(m_nPangType.ToString());
            //m_cstk2dSprite.color = m_stPangColor;
        }

        m_bPangState = true;
    }
    // ���� ����
    public void Remove()
    {
        m_cCollider.enabled = false;
        m_cRigidbody.Sleep();
        m_cTransform.position = m_stRemovePos;

        StopCoroutine("OnMouseDown");

        m_bPangState = false;
    }
    /*
    void GetColor()
    {
        m_stPangColor.a = 1.0f;
        switch (m_nPangType)
        {
            case 0:
                m_stPangColor.r = 1.0f;
                m_stPangColor.g = 1.0f;
                m_stPangColor.b = 1.0f;
                break;
            case 1:
                m_stPangColor.r = 1.0f;
                m_stPangColor.g = 0.0f;
                m_stPangColor.b = 0.0f;
                break;
            case 2:
                m_stPangColor.r = 0.0f;
                m_stPangColor.g = 1.0f;
                m_stPangColor.b = 0.0f;
                break;
            case 3:
                m_stPangColor.r = 0.0f;
                m_stPangColor.g = 0.0f;
                m_stPangColor.b = 1.0f;
                break;
            case 4:
                m_stPangColor.r = 1.0f;
                m_stPangColor.g = 1.0f;
                m_stPangColor.b = 0.0f;
                break;
            case 5:
                m_stPangColor.r = 1.0f;
                m_stPangColor.g = 0.0f;
                m_stPangColor.b = 1.0f;
                break;
            case 6:
                m_stPangColor.r = 0.0f;
                m_stPangColor.g = 1.0f;
                m_stPangColor.b = 1.0f;
                break;
            case 7:
                m_stPangColor.r = 1.0f;
                m_stPangColor.g = 0.5f;
                m_stPangColor.b = 0.0f;
                break;
            case 8:
                m_stPangColor.r = 0.5f;
                m_stPangColor.g = 0.0f;
                m_stPangColor.b = 1.0f;
                break;
        }
    }
    */
    // ���� Ŭ����
    public void Down()
    {
        StartCoroutine("OnMouseDown");
    }
    // ���� ������
    public void Up()
    {
        StopCoroutine("OnMouseDown");
    }

    // �ǹ����� ����
    public void Fever()
    {
        m_nPangType = Random.Range(0, 2);
        m_cstk2dSprite.spriteId = m_nSpriteId[m_nPangType];// m_cstk2dSprite.GetSpriteIdByName(m_nPangType.ToString());
        //GetColor();
        //m_cstk2dSprite.color = m_stPangColor;
    }
    // �ǹ����� ����
    public void NFever()
    {
        m_nPangType = Random.Range(0, 9);
        if (KDHManager.I.m_bPangKindSubState == true)
            m_nPangType = Random.Range(0, 7);
        m_cstk2dSprite.spriteId = m_nSpriteId[m_nPangType];// m_cstk2dSprite.GetSpriteIdByName(m_nPangType.ToString());
        //GetColor();
        //m_cstk2dSprite.color = m_stPangColor;
    }

    // ���� �巡�� �ϴ´�� ��������
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
                PangMNG.I.Up(gameObject);
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
