using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
    Animation m_cAnimation = null;

	// Use this for initialization
	void Start () {
        m_cAnimation = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!m_cAnimation.IsPlaying("menutitle"))
        {
            m_cAnimation.Play("ScaleAnimation");
        }
	}
}
