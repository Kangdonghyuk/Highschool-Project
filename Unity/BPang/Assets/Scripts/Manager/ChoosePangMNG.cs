using UnityEngine;
using System.Collections;

/**
    @file    : < ChoosePang >
    @author  : < Gtt >
    @version : < 1.0.0 >
    @brief   : < ���� �� ���� ��ũ��Ʈ >
 */


public class ChoosePangMNG : MonoBehaviour
{

    ArrayList m_rgcPang_ArrayList;  //!< ���õ� �� ����

    GameObject m_cPangEfect_Normal;
    AudioClip m_cPang_Sound;
    AudioClip m_cPangPang_Sound;

    private GameObject currnetObject = null;
    private static ChoosePangMNG m_Instance = null;
    public static ChoosePangMNG I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(ChoosePangMNG)) as ChoosePangMNG;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get ChoosePangMNG Instance");
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
	void Start () {
        m_rgcPang_ArrayList = new ArrayList();

        m_cPangEfect_Normal = (GameObject)Resources.Load("Prefabs/Pang/PangEfect", typeof(GameObject));
        m_cPang_Sound = (AudioClip)Resources.Load("Sound/Game/Pang/Pang", typeof(AudioClip));
        m_cPangPang_Sound = (AudioClip)Resources.Load("Sound/Game/Pang/PangPang", typeof(AudioClip));
	}

    /**
    @brief     : ���� ���� �Ǿ������ ����Ʈ�� ���õ� �� �߰�
    @return : void
    */
    public void DownPang(GameObject cPang_Object)
    {
        bool bPang_Overlap = true;  //!< ���õ� ���� �ߺ��ΰ� üũ
        foreach (GameObject cPang in m_rgcPang_ArrayList)
        {
            if (cPang == cPang_Object)
            {
                bPang_Overlap = false;
                break;
            }
        }
        if (bPang_Overlap == true)
        {
            cPang_Object.GetComponent<PangType>().OnClick();
            m_rgcPang_ArrayList.Add(cPang_Object);
            
            NGUITools.PlaySound(m_cPang_Sound);
        }
    }

    /**
	@brief     : �� ������ �����Ǿ����� ���õ� ���� ��� �������̸� �����ֱ�
	@return : void
    */
    public void UpPang()
    {
        bool bPang_Type_Check = true;   //!< ���õ� �ε��� ��� ���� Ÿ������ üũ

        GameObject cFirst_Pang = (GameObject)m_rgcPang_ArrayList[0];    //!< Ÿ���� �����̵� ù��° ��
        int nFirstPang_Type = cFirst_Pang.GetComponent<PangType>().GetType();   //!< ���� ���� Ÿ��
        int nChoosePang_Num = 0; //!< ���õ� ���� ����
        nChoosePang_Num = m_rgcPang_ArrayList.Count;

        foreach (GameObject cPang in m_rgcPang_ArrayList)
        {
            cPang.GetComponent<PangType>().OffClick();
            if (nFirstPang_Type != cPang.GetComponent<PangType>().GetType())
            {
                bPang_Type_Check = false;
                //break;
            }
        }

        if (bPang_Type_Check == true && nChoosePang_Num >= 3)
        {
            foreach (GameObject cPang in m_rgcPang_ArrayList)
            {
                CreatePangMNG.I.Remove_Pang(cPang);
                PangEfect(cPang.transform.position);
                Destroy(cPang);
            }
            ScoreMNG.I.AddScore(nChoosePang_Num * 100 + (nChoosePang_Num + 7));
            FeverMNG.I.AddFeverGage(nChoosePang_Num);
            NGUITools.PlaySound(m_cPangPang_Sound);
            //CreatePang.I.Sub_CreateNum(nChoosePang_Num);
        }
        m_rgcPang_ArrayList.Clear();
    }

    /**
	@brief     : �� ����Ʈ ����
	@return : void
    */
    public void PangEfect(Vector3 stPangEfect_Pos)
    {
        Instantiate(m_cPangEfect_Normal, stPangEfect_Pos, new Quaternion());
    }
}
