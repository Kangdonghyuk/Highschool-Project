using UnityEngine;
using System.Collections;

public class GORetryBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        Application.LoadLevel("DGPGame");
        System.GC.Collect();
    }
}