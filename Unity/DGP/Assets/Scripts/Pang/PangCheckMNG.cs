using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PangCheckMNG : MonoBehaviour
{
    //////////////////////
    public Combo m_csCombo; //Combo 스크립트
    public Fever m_csFever; // Fever 스크립트
    public PangEfectMNG m_csPangEfectMNG; // PangEfectMNG 스크립트
    //////////////////////

    GameObject m_cFeverPang;

    //ArrayList m_rgcCheckPang = null;
    //ArrayList m_rgcOkPang = null;

    List<GameObject> m_rgcCheckPang = null; // 팡 리스트
    List<GameObject> m_rgcOkPang = null; // 체크된 팡 리스트

   // GameObject m_cPang = null;
    //GameObject m_cTempPang = null;

    int m_nCheckPangType; // 체크할 팡 타입
    int m_nCheckPangTypeNum; // 체크할 팡의 개수
    int m_nTempOkPangNum; // 탐색할때 일정 횟수 이상 못하게 함
    int m_nOkPangNum; // 체크된 팡 개수

    ////////////// 거리 체크 변수(좌표)
    float m_fPang1X; 
    float m_fPang2X;
    float m_fPang1Y;
    float m_fPang2Y;
    //////////////


    private static PangCheckMNG m_Instance = null;
    public static PangCheckMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(PangCheckMNG)) as PangCheckMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get PangCheckMNG Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        m_csCombo = GameObject.Find("Combo").GetComponent<Combo>();
        m_csFever = GameObject.Find("FeverBar").GetComponent<Fever>();
        m_csPangEfectMNG = GameObject.Find("PangEfects").GetComponent<PangEfectMNG>();

        m_cFeverPang = GameObject.Find("FeverPang");

        m_rgcCheckPang = new List<GameObject>();
        m_rgcOkPang = new List<GameObject>();

        m_nCheckPangTypeNum = 0;
        m_nCheckPangType = 0;
        m_nTempOkPangNum = 0;
        m_nOkPangNum = 0;
    }

    // 사용안함
    public void Set()
    {
        AllCheck();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMNG.I.m_eGame_State == GameMNG.GAME_STATE.E_GAME_PLAY ||
            GameMNG.I.m_eGame_State == GameMNG.GAME_STATE.E_GAME_FEVER)
        {
            if (GameMNG.I.m_eGame_State == GameMNG.GAME_STATE.E_GAME_FEVER)
            {
                FeverCheck();
            }

            m_rgcCheckPang.Clear();
            m_rgcCheckPang = PangMNG.I.GetPang(m_nCheckPangType++);
            m_nCheckPangTypeNum = m_rgcCheckPang.Count;

            if (m_nCheckPangType == 9)
                m_nCheckPangType = 0;

            AllCheck();
        }
    }

    // 얻어온 팡을 가지고 체크
    void AllCheck()
    {
        for (int i = 0; i < m_nCheckPangTypeNum; i++)
        {
            //m_cPang = (GameObject)m_rgcCheckPang[i];
            m_nOkPangNum = 0;
            m_nTempOkPangNum = 0;

            m_rgcOkPang.Clear();
            m_rgcOkPang.Add(m_rgcCheckPang[i]);
            
            m_nOkPangNum += 1;

            Check(m_rgcCheckPang[i]);

            if (m_nOkPangNum >= 3)
            {
                //m_cTempPang = null;

                CameraShake.I.Shake();

                if (Random.Range(0, 6) == 1)
                {
                    PangMNG.I.CreateBoom();
                }

                SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);
                m_csFever.AddFever(m_nOkPangNum);
                int nCombo = m_csCombo.GetCombo();
                if(nCombo >= 200)
                    Score.I.AddScore(m_nOkPangNum * 100 * 10);
                else if(nCombo >= 100)
                    Score.I.AddScore(m_nOkPangNum * 100 * 5);
                else if (nCombo >= 50)
                    Score.I.AddScore(m_nOkPangNum * 100 * 4);
                else if (nCombo >= 25)
                    Score.I.AddScore(m_nOkPangNum * 100 * 3);
                else if (nCombo >= 10)
                    Score.I.AddScore(m_nOkPangNum * 100 * 2);
                else
                    Score.I.AddScore(m_nOkPangNum * 100);

                //m_cTempPang = (GameObject)m_rgcOkPang[0];
                //m_csCombo.AddCombo(1, m_cTempPang.transform.position);

                for (int j = 0; j < m_rgcOkPang.Count; j++)
                {
                    //m_cTempPang = (GameObject)m_rgcOkPang[j];
                    //Debug.Log(m_rgcOkPang[j].transform.name + " : "+j + " : " + m_rgcOkPang[j].GetComponent<Pang>().m_nPangType + " : " +  m_rgcOkPang[j].transform.position);
                    if (j == 0)
                    {
                        m_csCombo.AddCombo(1, m_rgcOkPang[j].transform.position);
                    }
                   
                    m_csPangEfectMNG.Create(m_rgcOkPang[j].transform.position);
                    //PangEfectMNG.I.Create(m_cTempPang.transform.position);
                    PangMNG.I.Remove(m_rgcOkPang[j]);
                }
                
                m_rgcOkPang.Clear();
               
                m_nOkPangNum = 0;
                m_nTempOkPangNum = 0;

                return;
            }
        }
    }

    // 팡 체크
    void Check(GameObject cPang)
    {
        if (m_nTempOkPangNum < m_nCheckPangTypeNum)
        {
            m_nTempOkPangNum += 1;

            for (int i = 0; i < m_nCheckPangTypeNum; i++)
            {
                //m_cTempPang = (GameObject)m_rgcCheckPang[i];
                if (m_rgcOkPang.Contains(m_rgcCheckPang[i]) == false)
                {
                    if (RadiusCheck(cPang, m_rgcCheckPang[i], 0.20f) == true)
                    {
                        m_rgcOkPang.Add(m_rgcCheckPang[i]);

                        m_nOkPangNum += 1;
                        Check(m_rgcCheckPang[i]);
                    }
                }
            }
        }
    }

    void FeverCheck()
    {
        m_rgcCheckPang.Clear();
        m_rgcOkPang.Clear();

        m_rgcCheckPang = PangMNG.I.GetPang();

        m_nCheckPangTypeNum = m_rgcCheckPang.Count;

        for (int i = 0; i < m_nCheckPangTypeNum; i++)
        {
            if (RadiusCheck(m_cFeverPang, m_rgcCheckPang[i], 0.2f) == true)
            {
                m_rgcOkPang.Add(m_rgcCheckPang[i]);
            }
        }


        if (m_rgcOkPang.Count > 0)
        {
            CameraShake.I.Shake();

            SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);
            Score.I.AddScore(m_nOkPangNum * 100);

            for (int i = 0; i < m_rgcOkPang.Count; i++)
            {
                m_csPangEfectMNG.Create(m_rgcOkPang[i].transform.position);
                m_csCombo.AddCombo(1, m_rgcOkPang[i].transform.position);
                //PangEfectMNG.I.Create(m_cTempPang.transform.position);
                PangMNG.I.Remove(m_rgcOkPang[i]);
            }
        }

        m_rgcCheckPang.Clear();
        m_rgcOkPang.Clear();

    }

    // 팡 주변의 같은 타입의 팡 반환
    public GameObject GetAroundPang(GameObject cPang)
    {
        int nPangType = cPang.GetComponent<Pang>().m_nPangType;

        m_rgcCheckPang.Clear();
        m_rgcCheckPang = PangMNG.I.GetPang(nPangType);
        int nPangNum = m_rgcCheckPang.Count;

        int i = 0;
        while (i < nPangNum)
        {
            if (m_rgcCheckPang[i] != cPang)
            {
                if (RadiusCheck(cPang, m_rgcCheckPang[i], 0.2f) == true)
                {
                    return m_rgcCheckPang[i];
                }
            }
            i += 1;
        }


        return null;
    }

    // 폭탄 체크
    public void PangBoom(GameObject cPangBoom)
    {
        m_rgcCheckPang.Clear();
        m_rgcOkPang.Clear();
        m_rgcCheckPang = PangMNG.I.GetPang();
        m_nCheckPangTypeNum = m_rgcCheckPang.Count;

        CameraShake.I.Shake();

        int i = 0;
        while (i < m_nCheckPangTypeNum)
        {
            //m_cTempPang = (GameObject)m_rgcCheckPang[i];
            if (RadiusCheck(cPangBoom, m_rgcCheckPang[i], 0.30f) == true)
            {
                m_rgcOkPang.Add(m_rgcCheckPang[i]);
            }
            i += 1;
        }

        m_nCheckPangTypeNum = m_rgcOkPang.Count;
        Score.I.AddScore(m_nCheckPangTypeNum);
        KDHManager.I.m_nPlayerMoney += 1;

        i = 0;
        while (i < m_nCheckPangTypeNum)
        {
            //m_cTempPang = (GameObject)m_rgcOkPang[i];
            if (i == 0)
            {
                if (GameMNG.I.m_eGame_State != GameMNG.GAME_STATE.E_GAME_OVER)
                {
                    m_csCombo.AddCombo(1, m_rgcOkPang[i].transform.position);
                }
            }
            m_csPangEfectMNG.Create(m_rgcOkPang[i].transform.position);
            //PangEfectMNG.I.Create(m_cTempPang.transform.position);
            PangMNG.I.Remove(m_rgcOkPang[i]);
            i += 1;
        }

        m_rgcCheckPang.Clear();
        m_rgcOkPang.Clear();

        m_nCheckPangTypeNum = 0;

    }

    // 거리 체크
    bool RadiusCheck(GameObject cPang1, GameObject cPang2, float fRadius)
    {
        m_fPang1X = cPang1.transform.position.x;
        m_fPang1Y = cPang1.transform.position.y;
        m_fPang2X = cPang2.transform.position.x;
        m_fPang2Y = cPang2.transform.position.y;

        float Dis = (((m_fPang2X - m_fPang1X) *
            (m_fPang2X - m_fPang1X))) +
            ((m_fPang2Y - m_fPang1Y) *
            (m_fPang2Y - m_fPang1Y));

        if (Dis < (fRadius * fRadius))
            return true;
        return false;
    }
}
