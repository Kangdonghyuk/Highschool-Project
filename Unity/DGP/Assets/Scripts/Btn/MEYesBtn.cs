using UnityEngine;
using System.Collections;

public class MEYesBtn : MonoBehaviour {

    Exit m_csExit;

	// Use this for initialization
	void Start () {
        m_csExit = transform.parent.GetComponent<Exit>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        m_csExit.OnOffExit();

        Application.Quit();
    }  
}
