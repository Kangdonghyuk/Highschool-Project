using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PangMNG : MonoBehaviour {
    public struct PANG
    {
        public GameObject m_cPangObject;
        public Pang m_csPang;
        public bool m_bPangState;

        public void Init(GameObject cPang)
        {
            m_cPangObject = cPang;
            m_csPang = m_cPangObject.GetComponent<Pang>();
            m_bPangState = false;
        }
        public void Create(Vector3 stPos)
        {
            m_csPang.Create(stPos);
            m_bPangState = true;
        }
        public void Remove()
        {
            m_csPang.Remove();
            m_bPangState = false;
        }
    } // 팡 구조체
    public struct PANGBOOM
    {
        public GameObject m_cPangBoomObject;
        public PangBoom m_csPangBoom;
        public bool m_bPangBoomState;

        public void Init(GameObject cPangBoom)
        {
            m_cPangBoomObject = cPangBoom;
            m_csPangBoom = m_cPangBoomObject.GetComponent<PangBoom>();
            m_bPangBoomState = false;
        }
        public void Create()
        {
            m_csPangBoom.Create();

            m_bPangBoomState = true;
        }
        public void Remove()
        {
            m_csPangBoom.Remove();

            m_bPangBoomState = false;
        }
    } // 폭탄 구조체

    Transform m_cTransform; // 자신의 Transform
    Transform m_cPangBoomTransform; // 폭탄 Transform
    Transform m_cChoosePangsTransform; // 선택된 팡 알리기위한 오브젝트들 Transform
    Transform[] m_cChoosePangTransform = new Transform[2]; // 선택된 팡 알리기 위한 오브젝트 Transform

    //ArrayList m_rgcGetPang;
    List<GameObject> m_rgcGetPang; // 넘겨줄 팡 List

    public GameObject[] m_cCheckPang; // 선택된 팡 저장 GameObject

    Vector3 m_stPangNormalPos; // 팡의 기본 좌표

    WaitForSeconds m_cWaitForSeconds; // 코루틴

    public PANG[] m_stPangs; // 팡 구조체들
    public PANGBOOM[] m_stPangBooms; // 폭탄 구조체들

    public bool m_bStartState; // 시작상태인지 체크

    public bool m_bCheckTest; // 사용안함

    public int m_nPangMaxNum; // 팡의 최대 개수
    public int m_nLivePangNum; // 살아있는 팡의 개수

    public int m_nPangBoomLiveNum;
    public int m_nPangBoomMaxNum; // 폭탄의 최대개수

    public int ShowIndex; // 사용안함

    private static PangMNG m_Instance = null;
    public static PangMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(PangMNG)) as PangMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get PangMNG Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

	// Use this for initialization
	void Start () {
        Debug.Log("PERAIEIWPQP");
        m_cTransform = transform;   
        m_nPangMaxNum = m_cTransform.childCount;

        m_cPangBoomTransform = GameObject.Find("PangBooms").transform;
        m_nPangBoomMaxNum = m_cPangBoomTransform.childCount;

        m_cChoosePangsTransform = GameObject.Find("ChoosePangs").transform;
        m_cChoosePangTransform[0] = m_cChoosePangsTransform.GetChild(0);
        m_cChoosePangTransform[1] = m_cChoosePangsTransform.GetChild(1);

        m_rgcGetPang = new List<GameObject>();

        m_cCheckPang = new GameObject[2];

        m_stPangNormalPos = new Vector3(-0.45f, 0.55f, 0.0f);

        m_cWaitForSeconds = new WaitForSeconds(0.05f);

        m_stPangs = new PANG[m_nPangMaxNum];
        m_stPangBooms = new PANGBOOM[m_nPangBoomMaxNum];

        int i=0;
        while (i < m_nPangMaxNum)
        {
            m_stPangs[i].Init(m_cTransform.GetChild(i).gameObject);
            i += 1;
        }
        i = 0;
        while (i < m_nPangBoomMaxNum)
        {
            m_stPangBooms[i].Init(m_cPangBoomTransform.GetChild(i).gameObject);
            i += 1;
        }

        m_bStartState = true;
        m_bCheckTest = false;

        m_nLivePangNum = 0;
        m_nPangBoomLiveNum = 0;

        ShowIndex = 0;
        if (KDHManager.I.m_bPangResenNumAddState == true)
            ShowIndex = 1;

        StartCoroutine("CreatePang");
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EnemyMNG.I.CreateMob();
            //CreateBoom();
        }
        if (Input.GetKeyDown(KeyCode.Menu))
        {
            m_nLivePangNum = 0;
            m_stPangNormalPos.x = -2.3f;
            for (int i = 0; i < m_nPangMaxNum; i++)
                m_stPangs[i].Remove();
            m_bCheckTest = !m_bCheckTest;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m_nLivePangNum = 0;
            m_stPangNormalPos.x = -2.3f;
            for (int i = 0; i < m_nPangMaxNum; i++)
                m_stPangs[i].Remove();
            ShowIndex += 1;
            if (ShowIndex >= 4)
                ShowIndex = 0;
        }
	}

    // ?초에 한번씩 팡 생성
    IEnumerator CreatePang()
    {
        yield return m_cWaitForSeconds;

        while (true)
        {
            //if (GameMNG.I.m_eGame_State == GameMNG.GAME_STATE.E_GAME_PLAY)
            {
                switch (ShowIndex)
                {
                    case 0:
                        Create(1);
                        break;
                    case 1:
                        Create(2);
                        break;
                    case 2:
                        Create(3);
                        break;
                    case 3:
                        Create(6);
                        break;
                }
            }

            yield return m_cWaitForSeconds;
        }
    }

    // 전달된 수만큼 팡 생성
    public void Create(int nNum)
    {
        int live = 0;
        int i = 0;
        while (i < m_nPangMaxNum)
        {
            if (live >= nNum || m_nLivePangNum >= m_nPangMaxNum)
                return;
            if (m_stPangs[i].m_bPangState == false)
            {
                if (m_bStartState == true)
                {
                    m_stPangs[i].Create(m_stPangNormalPos);

                    m_stPangNormalPos.x += 0.16f;
                    if (m_stPangNormalPos.x >= 0.45f)
                        m_stPangNormalPos.x = -0.45f;

                    live += 1;
                    m_nLivePangNum += 1;
                }
            }
            i += 1;
        }
    }

    // 팡 지우기
    public void Remove(GameObject cPang)
    {
        int i = 0;
        while (i < m_nPangMaxNum)
        {
            if (m_stPangs[i].m_cPangObject == cPang)
            {
                m_stPangs[i].Remove();
                m_nLivePangNum -= 1;
                return;
            }
            i += 1;
        }
    }

    // 사용안함
    public void AddRock()
    {
        if (m_nLivePangNum >= m_nPangMaxNum)
        {
            int i = 0;
            while (i < m_nPangMaxNum)
            {
                if (m_stPangs[i].m_bPangState == true)
                {
                    m_stPangs[i].Remove();
                    return;
                }
                i += 1;
            }
        }
        else
        {
            m_nLivePangNum += 1;
        }
    }

    // 폭탄 생성
    public void CreateBoom()
    {
        int i = 0;
        while (i < m_nPangBoomMaxNum)
        {
            if (m_stPangBooms[i].m_bPangBoomState == false)
            {
                m_stPangBooms[i].Create();
                m_nPangBoomLiveNum += 1;
                return;
            }
            i += 1;
        }
    }
    // 폭탄 지우기
    public void RemoveBoom(GameObject cBoomPang)
    {
        int i = 0;
        while (i < m_nPangBoomMaxNum)
        {
            if (m_stPangBooms[i].m_cPangBoomObject == cBoomPang)
            {
                PangCheckMNG.I.PangBoom(cBoomPang);
                m_stPangBooms[i].Remove();
                m_nPangBoomLiveNum -= 1;
                return;
            }
            i += 1;
        }
    }

    IEnumerator GameOverBoom()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            int i = 0;
            while (i < m_nPangBoomMaxNum)
            {
                if (m_stPangBooms[i].m_bPangBoomState == true)
                {
                    RemoveBoom(m_stPangBooms[i].m_cPangBoomObject);
                    break;
                }
                i += 1;
            }

            if (m_nPangBoomLiveNum == 0)
            {
                yield return new WaitForSeconds(0.5f);

                if (KDHManager.I.m_bFiveParsentAddState == true)
                {
                    Score.I.m_nScore = Score.I.m_nScore + (int)((((float)Score.I.m_nScore) / 100.0f) * 5.0f);
                }

                KDHManager.I.m_nPlayerScore = Score.I.m_nScore;

                KDHManager.I.m_bFiveParsentAddState = false;
                KDHManager.I.m_bPangKindSubState = false;
                KDHManager.I.m_bFeverTimeUpState = false;
                KDHManager.I.m_bComboTimeUpState = false;
                KDHManager.I.m_bPangResenNumAddState = false;
                KDHManager.I.m_bTimeUpState = false;

                GameSateData.I.SaveDataMoney();

                Application.LoadLevel("DGPGameOver");
                    Resources.UnloadUnusedAssets();
                    System.GC.Collect();
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    // 넘겨받은 팡 선택 (드래그가능하게)
    public void Down(GameObject cPang)
    {
         m_cCheckPang[0] = cPang;
         m_cCheckPang[0].GetComponent<Pang>().Down();

         m_cChoosePangTransform[0].position = cPang.transform.position;
         m_cChoosePangTransform[0].parent = cPang.transform;
    }
    // 넘겨받은 팡 선택 (드래그가능하게)
    public void DDown(GameObject cPang)
    {
        m_cCheckPang[1] = cPang;
        m_cCheckPang[1].GetComponent<Pang>().Down();

        m_cChoosePangTransform[1].position = cPang.transform.position;
        m_cChoosePangTransform[1].parent = cPang.transform;
    }
    // 기본 선택 팡 선택 취소
    public void Up()
    {
        if (m_cCheckPang != null)
        {
            m_cCheckPang[0].GetComponent<Pang>().Up();
            m_cCheckPang[0] = null;

            m_cChoosePangTransform[0].position = m_cChoosePangsTransform.position;
            m_cChoosePangTransform[0].parent = m_cChoosePangsTransform;
        }
    }
    // 넘겨받은 팡  선택 취소
    public void Up(GameObject cPang)
    {
        if (m_cCheckPang[0] == cPang)
        {
            m_cCheckPang[0].GetComponent<Pang>().Up();

            m_cChoosePangTransform[0].position = m_cChoosePangsTransform.position;
            m_cChoosePangTransform[0].parent = m_cChoosePangsTransform;
        }
        else if (m_cCheckPang[1] == cPang)
        {
            m_cCheckPang[1].GetComponent<Pang>().Up();

            m_cChoosePangTransform[1].position = m_cChoosePangsTransform.position;
            m_cChoosePangTransform[1].parent = m_cChoosePangsTransform;
        }
    }
    // 팡 전부 선택취소
    public void DUp()
    {
        if (m_cCheckPang[0] != null)
        {
            m_cCheckPang[0].GetComponent<Pang>().Up();

            m_cChoosePangTransform[0].position = m_cChoosePangsTransform.position;
            m_cChoosePangTransform[0].parent = m_cChoosePangsTransform;
        }
        if (m_cCheckPang[1] != null)
        {
            m_cCheckPang[1].GetComponent<Pang>().Up();

            m_cChoosePangTransform[1].position = m_cChoosePangsTransform.position;
            m_cChoosePangTransform[1].parent = m_cChoosePangsTransform;
        }
    }

    // 피버(팡 타입변경)
    public void Fever()
    {
        int i = 0;
        while (i < m_nPangMaxNum)
        {
            if (m_stPangs[i].m_bPangState == true)
            {
                m_stPangs[i].m_csPang.Fever();
            }
            i += 1;
        }
    }
    // 피버풀기
    public void NFever()
    {
        int i = 0;
        while (i < m_nPangMaxNum)
        {
            if (m_stPangs[i].m_bPangState == true)
            {
                m_stPangs[i].m_csPang.NFever();
            }
            i += 1;
        }
    }

    // 전달된 타입의 팡 반환
    public List<GameObject> GetPang(int nPangType)
    {
        m_rgcGetPang.Clear();
        int i = 0;
        while (i < m_nPangMaxNum)
        {
            if (m_bCheckTest == false)
            {
                if (m_stPangs[i].m_bPangState == true && m_stPangs[i].m_csPang.m_nPangType == nPangType)
                {
                    m_rgcGetPang.Add(m_stPangs[i].m_cPangObject);
                }
            }
            else
            {
                if (m_stPangs[i].m_bPangState == true)
                {
                    m_rgcGetPang.Add(m_stPangs[i].m_cPangObject);
                }
            }
            i += 1;
        }
        return m_rgcGetPang;
    }
    // 살아있는 팡 전부 반환
    public List<GameObject> GetPang()
    {
        m_rgcGetPang.Clear();

        int i = 0;
        while (i < m_nPangMaxNum)
        {
            if (m_stPangs[i].m_bPangState == true)
            {
                m_rgcGetPang.Add(m_stPangs[i].m_cPangObject);
            }
            i += 1;
        }

        return m_rgcGetPang;
    }
}
