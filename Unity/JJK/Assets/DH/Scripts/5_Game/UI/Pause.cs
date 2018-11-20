using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    Transform m_cPausePopupTm;

	// Use this for initialization
	void Start () {
        m_cPausePopupTm = transform.parent.FindChild("PausePopup");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUNE_MOUSEOVER);

        if (GameMng.I.m_eGameState == GameMng.GAME_STATE.E_GAME_PLAY)
        {
            GameMng.I.m_eGameState = GameMng.GAME_STATE.E_GAME_PAUSE;
            Time.timeScale = 0;
        }

        m_cPausePopupTm.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
