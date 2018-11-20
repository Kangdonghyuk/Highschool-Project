using UnityEngine;
using System.Collections;

/**
    @file    : < Pang >
    @author  : < Gtt >
    @version : < 1.0.0 >
    @brief   : < 팡의 기본 설정을 관리 하는 스크립트 >
 */


public class Pang : MonoBehaviour {

    /**
	@brief     : 팡이 화면 밖으로 나갔을경우 지워줌
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
