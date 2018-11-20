using UnityEngine;
using System.Collections;

public class CreatePangMNG : MonoBehaviour
{

    ArrayList m_rgcPang_ArrayList;

    GameObject m_cPang_Normal;

    bool m_bStartState;
    
    float m_fPassTime;
    float m_fPang_ResenTime;

    int m_nCreateNum;
    const int m_nMax_Pang_Num = 50;

    private GameObject currnetObject = null;
    private static CreatePangMNG m_Instance = null;
    public static CreatePangMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(CreatePangMNG)) as CreatePangMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get CreatePangMNG Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

    /**
    @brief     : �ʱ�ȭ
    @return : void
    */
	// Use this for initialization
	void Start () { 
        m_rgcPang_ArrayList = new ArrayList();

        m_cPang_Normal = (GameObject)Resources.Load("Prefabs/Pang/Pang", typeof(GameObject));

        m_bStartState = false;

        m_fPassTime = 0.0f;
        m_fPang_ResenTime = 0.1f;

        m_nCreateNum = 0;

        //Create(30);
	}

    /**
    @brief     : �����ð����� �� ����
    @return : void
    */
	// Update is called once per frame
	void Update () {
        m_fPassTime += Time.deltaTime;

        if (m_bStartState == false)
        {
            if (m_fPassTime >= m_fPang_ResenTime)
            {
                if (m_nCreateNum < m_nMax_Pang_Num)
                    Create(1);
                m_fPang_ResenTime = m_fPassTime + 0.1f;
            }

            if (m_nCreateNum >= 30)
            {
                m_fPang_ResenTime = m_fPassTime + 5.0f;
                m_bStartState = true;
            }
        }
        else if (m_bStartState == true)
        {
            m_fPassTime += Time.deltaTime;

            if (m_fPassTime >= m_fPang_ResenTime)
            {
                if (m_nCreateNum < m_nMax_Pang_Num)
                    Create(10);
                m_fPang_ResenTime = m_fPassTime + 5.0f;
            }
        }
	}

    /**
	@brief     : ���ڸ�ŭ ����
	@return : void
    */
    public void Create(int nCreateNum)
    {
        for (int nList = 0; nList < nCreateNum; nList++)
        {
            if (m_nCreateNum >= m_nMax_Pang_Num)
            {
                break;
            }
            m_nCreateNum++;
            LoadPang();
        }
    }

    /**
	@brief     : �� ������ ����Ʈ �߰�
	@return : void
    */
    void LoadPang()
    {
        m_rgcPang_ArrayList.Add(Instantiate(m_cPang_Normal, new Vector3(Random.Range(-2.0f, 2.1f), 4.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)) as GameObject);
        GameObject cPang = (GameObject)m_rgcPang_ArrayList[m_nCreateNum - 1];
        cPang.transform.parent = GameObject.Find("Pangs").transform;
    }

    /**
	@brief     : ������ �� �� ���̱�
	@return : void
    */
    public void Sub_CreateNum(int nSub_Num)
    {
        m_nCreateNum -= nSub_Num;
    }

    /**
    @brief     : �� ����Ʈ���� ����
    @return : void
    */
    public void Remove_Pang(GameObject cPang) {
        m_nCreateNum -= 1;
        m_rgcPang_ArrayList.Remove(cPang);
    }

    /**
	@brief     : ������ �ε� �ǹ�
	@return : void
    */
    public void Fever()
    {
        foreach (GameObject cPang in m_rgcPang_ArrayList)
        {
            cPang.GetComponent<PangType>().Fever();
        }
    }

    /**
	@brief     : �ǹ� Ǯ��
	@return : void
    */
    public void NFever()
    {
        foreach (GameObject cPang in m_rgcPang_ArrayList)
        {
            cPang.GetComponent<PangType>().NFever();
        }
    }
}
