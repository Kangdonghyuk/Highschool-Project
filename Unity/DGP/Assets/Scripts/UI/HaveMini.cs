using UnityEngine;
using System.Collections;

public class HaveMini : MonoBehaviour {

    UILabel m_csHaveMiniUILabel;

	// Use this for initialization
	void Start () {
        m_csHaveMiniUILabel = transform.FindChild("Label").GetComponent<UILabel>();

        m_csHaveMiniUILabel.text = KDHManager.I.m_nPlayerMoney.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        m_csHaveMiniUILabel.text = KDHManager.I.m_nPlayerMoney.ToString();
	}
}
