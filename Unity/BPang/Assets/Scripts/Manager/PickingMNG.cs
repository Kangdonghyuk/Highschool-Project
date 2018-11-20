using UnityEngine;
using System.Collections;

/**
	@file    : < Picking >
	@author  : < Gtt >
	@version : < 1.0.0 >
	@brief   : < 마우스 및 터치 픽킹 관리 스크립트 >
 */


public class PickingMNG : MonoBehaviour
{
    bool m_bChoosePang_State;   //!< 팡의 선택중 체크 여부

    // Use this for initialization
    /**
	@brief     : 초기화
	@return : void
    */
    void Start()
    {
        m_bChoosePang_State = false;
    }

    /**
	@brief     : 매 프레임 돌며 클릭 및 터치 확인
	@return : void
    */
    void Update()
    {
        RaycastHit stHit;   //!< 픽킹된 오브젝트 정보 저장
        if (Input.GetMouseButton(0) == true) //마우스를 눌르면
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //현재 마우스클릭한 위치

            if (Physics.Raycast(ray, out stHit, 100)) // 피킹이 되면 m_Hit에 피킹된 오브젝트정보가 달려온다.
            {
                if (stHit.transform.tag == "PANG")
                {
                    m_bChoosePang_State = true;
                    ChoosePangMNG.I.DownPang(stHit.transform.gameObject);
                    //Debug.Log(stHit.transform.name);
                }
            }
        }
        else
        {
            if (m_bChoosePang_State == true)
            {
                ChoosePangMNG.I.UpPang();
                m_bChoosePang_State = false;
            }
        }

    }
}
