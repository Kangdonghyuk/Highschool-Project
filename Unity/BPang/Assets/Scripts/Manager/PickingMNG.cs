using UnityEngine;
using System.Collections;

/**
	@file    : < Picking >
	@author  : < Gtt >
	@version : < 1.0.0 >
	@brief   : < ���콺 �� ��ġ ��ŷ ���� ��ũ��Ʈ >
 */


public class PickingMNG : MonoBehaviour
{
    bool m_bChoosePang_State;   //!< ���� ������ üũ ����

    // Use this for initialization
    /**
	@brief     : �ʱ�ȭ
	@return : void
    */
    void Start()
    {
        m_bChoosePang_State = false;
    }

    /**
	@brief     : �� ������ ���� Ŭ�� �� ��ġ Ȯ��
	@return : void
    */
    void Update()
    {
        RaycastHit stHit;   //!< ��ŷ�� ������Ʈ ���� ����
        if (Input.GetMouseButton(0) == true) //���콺�� ������
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //���� ���콺Ŭ���� ��ġ

            if (Physics.Raycast(ray, out stHit, 100)) // ��ŷ�� �Ǹ� m_Hit�� ��ŷ�� ������Ʈ������ �޷��´�.
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
