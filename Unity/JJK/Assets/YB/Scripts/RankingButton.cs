using UnityEngine;
using System.Collections;

public class RankingButton : MonoBehaviour {
    public GameObject m_cRankingPopup = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        GameObject cGameObject = Instantiate(m_cRankingPopup) as GameObject;
        cGameObject.transform.parent = GameObject.Find("RankingOffset").transform;
        cGameObject.transform.localScale = Vector3.one;


    }
}
