using UnityEngine;
using System.Collections;

/**
    @file    : < ChoosePang >
    @author  : < Gtt >
    @version : < 1.0.0 >
    @brief   : < 선택 팡 관리 스크립트 >
 */


public class ChoosePangMNG : MonoBehaviour
{

    ArrayList m_rgcPang_ArrayList;  //!< 선택된 팡 저장

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
    @brief     : 초기화
    @return : void
    */
	void Start () {
        m_rgcPang_ArrayList = new ArrayList();

        m_cPangEfect_Normal = (GameObject)Resources.Load("Prefabs/Pang/PangEfect", typeof(GameObject));
        m_cPang_Sound = (AudioClip)Resources.Load("Sound/Game/Pang/Pang", typeof(AudioClip));
        m_cPangPang_Sound = (AudioClip)Resources.Load("Sound/Game/Pang/PangPang", typeof(AudioClip));
	}

    /**
    @brief     : 팡이 선택 되었을경우 리스트에 선택된 팡 추가
    @return : void
    */
    public void DownPang(GameObject cPang_Object)
    {
        bool bPang_Overlap = true;  //!< 선택된 팡이 중복인가 체크
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
	@brief     : 팡 선택이 해제되었을때 선택된 팡이 모두 같은팡이면 지워주기
	@return : void
    */
    public void UpPang()
    {
        bool bPang_Type_Check = true;   //!< 선택된 팡들이 모두 같은 타입인지 체크

        GameObject cFirst_Pang = (GameObject)m_rgcPang_ArrayList[0];    //!< 타입의 기준이될 첫번째 팡
        int nFirstPang_Type = cFirst_Pang.GetComponent<PangType>().GetType();   //!< 기준 팡의 타입
        int nChoosePang_Num = 0; //!< 선택된 팡의 개수
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
	@brief     : 팡 이펙트 생성
	@return : void
    */
    public void PangEfect(Vector3 stPangEfect_Pos)
    {
        Instantiate(m_cPangEfect_Normal, stPangEfect_Pos, new Quaternion());
    }
}
