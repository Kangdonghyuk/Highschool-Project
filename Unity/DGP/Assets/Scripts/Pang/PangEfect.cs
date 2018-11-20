using UnityEngine;
using System.Collections;

public class PangEfect : MonoBehaviour {

    tk2dAnimatedSprite m_cstk2dAnimatedSprite; // tk2dAnimatedSprited 스크립트

    Transform m_cTransform; // 자신의 Transform

    //////////////////////
    static Vector3 m_stNormalPos = new Vector3(-0.5f, 2.0f, 0.0f); // 이펙트들의 기본 좌표
    //////////////////////

    public bool m_bPangEfectState; // 현재 상태

	// Use this for initialization
	void Start () {
        m_cstk2dAnimatedSprite = GetComponent<tk2dAnimatedSprite>();

        m_cTransform = GetComponent<Transform>();

        m_bPangEfectState = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_bPangEfectState == true && m_cstk2dAnimatedSprite.isPlaying() == false) {
            m_cTransform.position = m_stNormalPos;
            m_bPangEfectState = false;
        }
	}

    // 얻어온 좌표에서 이펙트 애니메이션 재생
    public void Create(Vector3 stPos)
    {
        m_cTransform.position = stPos;

        m_cstk2dAnimatedSprite.Play();

        m_bPangEfectState = true;
    }
}
