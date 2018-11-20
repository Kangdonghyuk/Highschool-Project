using UnityEngine;
using System.Collections;

public class MGameStartBtn : MonoBehaviour {

    Store m_csStore;
    Exit m_csExit;

	// Use this for initialization
	void Start () {
        m_csStore = GameObject.Find("StorePopup").GetComponent<Store>();
        m_csExit = GameObject.Find("ExitPopup").GetComponent<Exit>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_csExit.OnOffExit();
        }
	}

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        m_csStore.OnOffStore();

        /*Application.LoadLevel("DGPGame");
        System.GC.Collect();*/
    }
}
