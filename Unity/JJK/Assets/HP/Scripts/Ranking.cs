using UnityEngine;
using System.Collections;

public class Ranking : MonoBehaviour {
    UILabel m_cLabel = null;

    int num;

	// Use this for initialization
	void Start () {
        m_cLabel = GetComponent<UILabel>();

        num = 0;

        num = (int)m_cLabel.text[0] - '1';
        Debug.Log(num);

        m_cLabel.text = (num+1).ToString() +   "µî : " + HPMng.I.m_nScore[num].ToString() + "°³";
	}
	
	// Update is called once per frame
	void Update () {

	}
}
