using UnityEngine;
using System.Collections;

public class GOMenuBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        Application.LoadLevel("DGPRanking");
        //System.GC.Collect();
    }
}
