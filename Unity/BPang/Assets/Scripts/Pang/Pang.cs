using UnityEngine;
using System.Collections;

/**
    @file    : < Pang >
    @author  : < Gtt >
    @version : < 1.0.0 >
    @brief   : < ���� �⺻ ������ ���� �ϴ� ��ũ��Ʈ >
 */


public class Pang : MonoBehaviour {

    /**
	@brief     : ���� ȭ�� ������ ��������� ������
	@return : void
    */
    void Update()
    {
        if (Mathf.Abs(transform.position.y) > 5)
        {
            if (Mathf.Abs(transform.position.x) > 3)
            {
                //CreatePang.I.Sub_CreateNum(1);
                CreatePangMNG.I.Remove_Pang(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
