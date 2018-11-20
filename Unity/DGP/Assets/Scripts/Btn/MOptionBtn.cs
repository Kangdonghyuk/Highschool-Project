using UnityEngine;
using System.Collections;

public class MOptionBtn : MonoBehaviour {

    Option m_csOption;

	// Use this for initialization
	void Start () {
        m_csOption = GameObject.Find("OptionPopup").GetComponent<Option>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        m_csOption.OnOffOption();
    }
}
