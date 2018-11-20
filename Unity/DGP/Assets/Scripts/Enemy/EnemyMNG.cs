using UnityEngine;
using System.Collections;

public class EnemyMNG : MonoBehaviour {
    public struct MOB
    {
        public GameObject m_cMobObject;
        public Mob m_csMob;
        public bool m_bMobState;

        public void Init(GameObject cMob)
        {
            m_cMobObject = cMob;
            m_csMob = m_cMobObject.GetComponent<Mob>();
            m_bMobState = false;
        }
        public void Create()
        {
            m_csMob.Create();
            m_bMobState = true;
        }
        public void Remove()
        {
            m_csMob.Remove();
            m_bMobState = false;
        }
    }
    public struct ROCK
    {
        public GameObject m_cRockObject;
        public Rock m_csRock;
        public bool m_bRockState;

        public void Init(GameObject cMob)
        {
            m_cRockObject = cMob;
            m_csRock = m_cRockObject.GetComponent<Rock>();
            m_bRockState = false;
        }
        public void Create()
        {
            m_csRock.Create();
            m_bRockState = true;
        }
        public void Remove()
        {
            m_csRock.Remove();
            m_bRockState = false;
        }
    }

    Transform m_cMobTransform;
    Transform m_cRockTransform;

    WaitForSeconds m_cMobWaitForSeconds;

    public MOB[] m_stMobs;
    public ROCK[] m_stRocks;

    public int m_nMobMaxNum;
    public int m_nRockMaxNum;

    private static EnemyMNG m_Instance = null;
    public static EnemyMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(EnemyMNG)) as EnemyMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get EnemyMNG Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }
	// Use this for initialization
	void Start () {
        m_cMobTransform = transform; 
        m_nMobMaxNum = m_cMobTransform.childCount;

        m_cRockTransform = GameObject.Find("Rocks").transform;
        m_nRockMaxNum = m_cRockTransform.childCount;
        
        m_cMobWaitForSeconds = new WaitForSeconds(20.0f);

        m_stMobs = new MOB[m_nMobMaxNum];
        m_stRocks = new ROCK[m_nRockMaxNum];

        int i = 0;
        while (i < m_nMobMaxNum)
        {
            m_stMobs[i].Init(m_cMobTransform.GetChild(i).gameObject);
            i += 1;
        }
        i = 0;
        while(i < m_nRockMaxNum) {
            m_stRocks[i].Init(m_cRockTransform.GetChild(i).gameObject);
            i+=1;
        }

        StartCoroutine("IECreateMob");
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator IECreateMob()
    {
        while (true)
        {
            yield return m_cMobWaitForSeconds;

            CreateMob();
        }
    }

    public void CreateMob()
    {
        int i = 0;
        while (i < m_nMobMaxNum)
        {
            if (m_stMobs[i].m_bMobState == false)
            {
                m_stMobs[i].Create();
                return;
            }
            i += 1;
        }
    }
    public void RemoveMob(GameObject cMob)
    {
        int i = 0;
        while (i < m_nMobMaxNum)
        {
            if (m_stMobs[i].m_cMobObject == cMob)
            {
                m_stMobs[i].Remove();
                return;
            }
            i += 1;
        }
    }
    public void HeatMob(GameObject cMob, int nDamage)
    {
        int i = 0;
        while (i < m_nMobMaxNum)
        {
            if (m_stMobs[i].m_cMobObject == cMob)
            {
                m_stMobs[i].m_csMob.Heat(nDamage);
                return;
            }
            i += 1;
        }
    }

    public void CreateRock() {
        int i=0;
        while(i < m_nRockMaxNum) {
            if(m_stRocks[i].m_bRockState == false) {
                m_stRocks[i].Create();
                PangMNG.I.AddRock();
                return;
            }
            i += 1;
        }
    }
    public void RemoveRock() {
    }
}
