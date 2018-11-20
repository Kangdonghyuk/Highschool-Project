using UnityEngine;
using System.Collections;

// 팡의 기본적인 데이터 저장

public class Pang : MonoBehaviour {
    tk2dSprite m_cstk2dSprite; //tk2dSprite 스크립트 저장 변수

    Transform m_cTransform; // 해당 팡의 Transform 변수
    SphereCollider m_cCollider; // 해당 팡의 Collider 변수
    Rigidbody m_cRigidbody; // 해당팡의 Rigidbody 변수

    static Vector3 m_stRemovePos = new Vector3(0.0f, 2.0f, 0.0f); // 팡의 기본위치(static) 변수
    Vector3 m_stGetPos; // 해당 팡의 좌표 변수

    bool m_bPangState; // 해당 팡의 상태 변수(활성,비활성)

    public int m_nPangType; // 해당 팡의 타입 변수

   // static int m_nAddName;
    static float m_fCreateNum; // 팡들의 좌표를 점점 앞으로 변수
    float m_fLateZ; // 해당 팡의 Z좌표 변수
    /////////////////////////////////////
    static int[] m_nSpriteId = new int[9]; // 각 타입당 SpriteID 변수
    /////////////////////////////////////
    static Vector3 m_stVelocity = new Vector3(0.0f, 0.0f, 0.0f); // 팡들의 기본 가속도 변수
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

    // 전달받은 좌표로 팡을 생성
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
    // 팡을 지움
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
    // 팡을 클릭시
    public void Down()
    {
        StartCoroutine("OnMouseDown");
    }
    // 팡을 땠을시
    public void Up()
    {
        StopCoroutine("OnMouseDown");
    }

    // 피버상태 적용
    public void Fever()
    {
        m_nPangType = Random.Range(0, 2);
        m_cstk2dSprite.spriteId = m_nSpriteId[m_nPangType];// m_cstk2dSprite.GetSpriteIdByName(m_nPangType.ToString());
        //GetColor();
        //m_cstk2dSprite.color = m_stPangColor;
    }
    // 피버상태 해제
    public void NFever()
    {
        m_nPangType = Random.Range(0, 9);
        if (KDHManager.I.m_bPangKindSubState == true)
            m_nPangType = Random.Range(0, 7);
        m_cstk2dSprite.spriteId = m_nSpriteId[m_nPangType];// m_cstk2dSprite.GetSpriteIdByName(m_nPangType.ToString());
        //GetColor();
        //m_cstk2dSprite.color = m_stPangColor;
    }

    // 팡의 드래그 하는대로 움직여줌
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
