using UnityEngine;
using System.Collections;

public class MOVirOnOffBtn : MonoBehaviour {

    UISlicedSprite m_Background;

    bool m_bOptionState;

    // Use this for initialization
    void Start()
    {
        m_Background = transform.FindChild("Background").GetComponent<UISlicedSprite>();

        m_bOptionState = KDHManager.I.m_bVibrateState;
        if (m_bOptionState == true)
        {
            m_Background.spriteName = "ON";
        }
        else
        {
            m_Background.spriteName = "OFF";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);
        m_bOptionState = !m_bOptionState;
        if (m_bOptionState == true)
        {
            m_Background.spriteName = "ON";
            KDHManager.I.m_bVibrateState = true;
        }
        else
        {
            m_Background.spriteName = "OFF";
            KDHManager.I.m_bVibrateState = false;
        }
    }
}
