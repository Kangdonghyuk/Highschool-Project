using UnityEngine;
using System.Collections;

public class MCreditBtn : MonoBehaviour {

    Credit m_csCredit;

	// Use this for initialization
	void Start () {
        m_csCredit = GameObject.Find("CreditPopup").GetComponent<Credit>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        m_csCredit.OnOffCredit();
    }
}
