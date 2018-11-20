using UnityEngine;
using System.Collections;

public class PauseGoHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUNE_MOUSEOVER);
        Application.LoadLevel("2_Menu");
    }
}
