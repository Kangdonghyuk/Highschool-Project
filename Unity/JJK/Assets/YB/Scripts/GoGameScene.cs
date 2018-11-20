using UnityEngine;
using System.Collections;

public class GoGameScene : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnClick()
    {
        if (HPMng.I.m_bTutoState == true)
        {
            HPMng.I.m_bTutoState = false;
            GameSateData.I.SaveData();
            AutoFade.LoadLevel("6_Tutorial", 1.0f, 1.0f, Color.black);
        }
        else
        {
            AutoFade.LoadLevel("5_Game", 1.0f, 1.0f, Color.black);
        }
    }
}
