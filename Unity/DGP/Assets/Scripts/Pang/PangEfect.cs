using UnityEngine;
using System.Collections;

public class PangEfect : MonoBehaviour {

    tk2dAnimatedSprite m_cstk2dAnimatedSprite; // tk2dAnimatedSprited ��ũ��Ʈ

    Transform m_cTransform; // �ڽ��� Transform

    //////////////////////
    static Vector3 m_stNormalPos = new Vector3(-0.5f, 2.0f, 0.0f); // ����Ʈ���� �⺻ ��ǥ
    //////////////////////

    public bool m_bPangEfectState; // ���� ����

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

    // ���� ��ǥ���� ����Ʈ �ִϸ��̼� ���
    public void Create(Vector3 stPos)
    {
        m_cTransform.position = stPos;

        m_cstk2dAnimatedSprite.Play();

        m_bPangEfectState = true;
    }
}
