using UnityEngine;
using System.Collections;

public class MSIFeverTimeUpBtn : MonoBehaviour {

    UICheckbox m_csUICheckbox;

    int m_nState;

    // Use this for initialization
    void Start()
    {
        m_csUICheckbox = GetComponent<UICheckbox>();
        m_csUICheckbox.isChecked = KDHManager.I.m_bFeverTimeUpState;

        m_nState = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        if (KDHManager.I.m_bFeverTimeUpState == false)
        {
            if (KDHManager.I.m_nPlayerMoney >= m_nState)
            {
                KDHManager.I.m_nPlayerMoney -= m_nState;
                KDHManager.I.m_bFeverTimeUpState = true;
                m_csUICheckbox.isChecked = true;
            }
            else
            {
                KDHManager.I.m_bFeverTimeUpState = false;
                m_csUICheckbox.isChecked = false;
            }
        }
        else
        {
            KDHManager.I.m_bFeverTimeUpState = false;
            KDHManager.I.m_nPlayerMoney += m_nState;
            m_csUICheckbox.isChecked = false;
        }
    }
}
