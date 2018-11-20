using UnityEngine;
using System.Collections;

public class PangEfect : MonoBehaviour {
    tk2dAnimatedSprite m_cstk2dAnimatedSprite;

    /**
    @brief     : �ʱ�ȭ
    @return : void
    */
	// Use this for initialization
	void Start () {
        m_cstk2dAnimatedSprite = transform.FindChild("AnimatedSprite").GetComponent<tk2dAnimatedSprite>();
	}

    /**
    @brief     : �ִϸ��̼� �ٵ��� ������
    @return : void
    */
	// Update is called once per frame
	void Update () {
        if (m_cstk2dAnimatedSprite.isPlaying() == false)
            Destroy(gameObject);
	}
}
