using UnityEngine;
using System.Collections;

public class FeverGage : MonoBehaviour {

    UISlider m_csUISlider;

    float m_fFeverGage_Value;

    /**
    @brief     : �ʱ�ȭ
    @return : void
    */
	// Use this for initialization
	void Start () {
        m_csUISlider = GetComponent<UISlider>();

        m_fFeverGage_Value = 0.0f;
	}

    /**
    @brief     : �ǹ������� ǥ��
    @return : ����
    */
	// Update is called once per frame
	void Update () {
        m_csUISlider.sliderValue = m_fFeverGage_Value;
	}

    /**
	@brief     : �ǹ������� ����
	@return : void
    */
    public void SetFeverGageValue(float fFeverGageValue)
    {
        m_fFeverGage_Value = fFeverGageValue;
    }
}
