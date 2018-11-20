using UnityEngine;
using System.Collections;

public class OverScore : MonoBehaviour {

    UILabel m_csUILabel;

	// Use this for initialization
	void Start () {

        m_csUILabel = transform.GetComponent<UILabel>();

        m_csUILabel.text = KDHManager.I.m_nPlayerScore.ToString();
	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
