using UnityEngine;
using System.Collections;

public class GMenuBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);

        Time.timeScale = 1.0f;
       // GameMNG.I.OnOffGamePause();
        Application.LoadLevel("DGPMenu");
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
        
    }
}
