using UnityEngine;
using System.Collections;

public class FeverGage : MonoBehaviour {

    UISlider m_csUISlider;

    float m_fFeverGage_Value;

    /**
    @brief     : 초기화
    @return : void
    */
	// Use this for initialization
	void Start () {
        m_csUISlider = GetComponent<UISlider>();

        m_fFeverGage_Value = 0.0f;
	}

    /**
    @brief     : 피버게이지 표시
    @return : 리턴
    */
	// Update is called once per frame
	void Update () {
        m_csUISlider.sliderValue = m_fFeverGage_Value;
	}

    /**
	@brief     : 피버게이지 셋팅
	@return : void
    */
    public void SetFeverGageValue(float fFeverGageValue)
    {
        m_fFeverGage_Value = fFeverGageValue;
    }
}
