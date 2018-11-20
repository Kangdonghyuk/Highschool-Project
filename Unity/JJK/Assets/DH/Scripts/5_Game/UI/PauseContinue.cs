using UnityEngine;
using System.Collections;

public class PauseContinue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUNE_MOUSEOVER);

        GameMng.I.m_eGameState = GameMng.GAME_STATE.E_GAME_PLAY;
        Time.timeScale = 1;

        transform.parent.position = new Vector3(400.0f, 0.0f, 0.0f);
    }
}
