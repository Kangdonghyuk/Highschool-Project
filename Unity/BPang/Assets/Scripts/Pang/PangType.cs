using UnityEngine;
using System.Collections;

/**
    @file    : < PangType >
    @author  : < Gtt >
    @version : < 1.0.0 >
    @brief   : < ���� Ÿ���� �����ϴ� ��ũ��Ʈ >
 */


public class PangType : MonoBehaviour {

    tk2dSprite m_cstk2d_Sprite; //!< ���� tk2dSprite ��ũ��Ʈ 

    Color m_cColor;

    int m_nPang_Type;   //!< ���� Ÿ��

    /**
    @brief     : �ʱ�ȭ
    @return : void
    */
	void Start () {
        m_cstk2d_Sprite = GetComponent<tk2dSprite>();

        m_cColor = new Color(0.0f, 0.0f, 0.0f);

        if (FeverMNG.I.GetFeverState() == true)
            m_nPang_Type = Random.Range(0, 2);
        else
            m_nPang_Type = Random.Range(0, 4);

        GetColor(m_nPang_Type);
        m_cstk2d_Sprite.color = m_cColor;
	}

    /**
	@brief     : ���� Ÿ�� ��ȯ �Լ�
	@return : int <�� Ÿ��>
    */
    public int GetType()
    {
        return m_nPang_Type;
    }

    /**
	@brief     : ���� Ÿ���� �������ִ� �Լ�
	@return : Color <�� Ÿ�� �÷�>
    */
    void GetColor(int nType)
    {
        switch (nType)
        {
            case 0:
                m_cColor.r = 1.0f;
                m_cColor.g = 1.0f;
                m_cColor.b = 1.0f;
                break;
            case 1:
                m_cColor.r = 1.0f;
                m_cColor.g = 0.0f;
                m_cColor.b = 0.0f;
                break;
            case 2:
                m_cColor.r = 0.0f;
                m_cColor.g = 1.0f;
                m_cColor.b = 0.0f;
                break;
            case 3:
                m_cColor.r = 0.0f;
                m_cColor.g = 0.0f;
                m_cColor.b = 1.0f;
                break;
            case 4:
                m_cColor.r = 1.0f;
                m_cColor.g = 1.0f;
                m_cColor.b = 0.0f;
                break;
            case 5:
                m_cColor.r = 1.0f;
                m_cColor.g = 0.0f;
                m_cColor.b = 1.0f;
                break;
            case 6:
                m_cColor.r = 0.0f;
                m_cColor.g = 1.0f;
                m_cColor.b = 1.0f;
                break;
            case 7:
                m_cColor.r = 0.0f;
                m_cColor.g = 0.0f;
                m_cColor.b = 0.0f;
                break;
        }
    }

    public void Fever()
    {
        m_nPang_Type = Random.Range(0, 2);
        GetColor(m_nPang_Type);

        m_cstk2d_Sprite.color = m_cColor;
    }

    public void NFever()
    {
        m_nPang_Type = Random.Range(0, 4);
        GetColor(m_nPang_Type);

        m_cstk2d_Sprite.color = m_cColor;
    }

    public void OnClick()
    {
        m_cColor.a = 0.5f;
        m_cstk2d_Sprite.color = m_cColor;
    }

    public void OffClick()
    {
        m_cColor.a = 1.0f;
        m_cstk2d_Sprite.color = m_cColor;
    }
}
