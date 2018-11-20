using UnityEngine;
using System.Collections;

public class TutorialArrow : MonoBehaviour {
    Vector3 m_stPosition = Vector3.zero;
    int m_nTurn = -1;
    bool m_bMove = false; // Base : Left
    bool m_bReverse = false; // 180.0f * m_bReverse, Base : Right

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        TargetPosition();
        ArrowMove();
        RotationSetting();
	}

    void TargetPosition()
    {
        if (m_nTurn != Tutorial.I.m_nTurn)
        {
            m_nTurn = Tutorial.I.m_nTurn;

            switch (Tutorial.I.m_nTurn)
            {
                case 0:
                case 1:
                    m_stPosition = Vector3.right * 1000.0f;
                    transform.localPosition = m_stPosition;
                    break;
                case 2:
                    m_stPosition = Vector3.right * 75.0f + Vector3.up * 230.0f;
                    transform.localPosition = m_stPosition;
                    m_bReverse = false;
                    break;
                case 3:
                    m_stPosition = Vector3.right * 80.0f;
                    transform.localPosition = m_stPosition;
                    m_bReverse = false;
                    break;
                case 4:
                    m_stPosition = Vector3.up * 200.0f;
                    transform.localPosition = m_stPosition;
                    m_bReverse = false;
                    break;
                case 5:
                case 6:
                case 7:
                    m_stPosition = Vector3.right * 1000.0f;
                    transform.localPosition = m_stPosition;
                    break;
                case 8:
                    if ((Tutorial.I.m_nTurn == 8 || Tutorial.I.m_nTurn == 12) && Tutorial.I.m_bClear == false)
                    {
                        m_stPosition = Vector3.right * 1000.0f;
                        transform.localPosition = m_stPosition;
                        m_nTurn = 7;
                    }
                    else
                    {
                        m_stPosition = Vector3.up * 200.0f;
                        transform.localPosition = m_stPosition;
                        m_bReverse = true;
                    }
                    break;
                case 9:
                    m_stPosition = Vector3.left * 70.0f + Vector3.up * 100.0f;
                    transform.localPosition = m_stPosition;
                    m_bReverse = true;
                    break;
                case 10:
                case 11:
                    m_stPosition = Vector3.right * 1000.0f;
                    transform.localPosition = m_stPosition;
                    break;
                case 12:
                    if ((Tutorial.I.m_nTurn == 8 || Tutorial.I.m_nTurn == 12) && Tutorial.I.m_bClear == false)
                    {
                        m_stPosition = Vector3.right * 1000.0f;
                        transform.localPosition = m_stPosition;
                        m_nTurn = 7;
                    }
                    else
                    {
                        m_stPosition = Vector3.left * 60.0f + Vector3.up * 20.0f;
                        transform.localPosition = m_stPosition;
                        m_bReverse = true;
                    }
                    break;
                case 13:
                    m_stPosition = Vector3.right * 1000.0f;
                    transform.localPosition = m_stPosition;
                    break;
                case 14:
                    m_stPosition = Vector3.up * 200.0f;
                    transform.localPosition = m_stPosition;
                    m_bReverse = true;
                    break;
                case 15: case 16:
                    m_stPosition = Vector3.right * 1000.0f;
                    transform.localPosition = m_stPosition;
                    break;
            }
        }
    }

    void ArrowMove()
    {
        if (!m_bReverse)
        {
            if (!m_bMove)
            {
                transform.Translate(Vector3.left * 0.25f * Time.deltaTime);

                if (transform.localPosition.x < m_stPosition.x - 10)
                {
                    m_bMove = true;
                }
            }
            else
            {
                transform.Translate(Vector3.right * 0.25f * Time.deltaTime);

                if (transform.localPosition.x > m_stPosition.x)
                {
                    m_bMove = false;
                }
            }
        }
        else
        {
            if (!m_bMove)
            {
                transform.Translate(Vector3.right * 0.25f * Time.deltaTime);

                if (transform.localPosition.x < m_stPosition.x)
                {
                    m_bMove = true;
                }
            }
            else
            {
                transform.Translate(Vector3.left * 0.25f * Time.deltaTime);

                if (transform.localPosition.x > m_stPosition.x + 10)
                {
                    m_bMove = false;
                }
            }
        }
    }

    void RotationSetting()
    {
        transform.localRotation = Quaternion.identity;
        transform.Rotate(0.0f, 180.0f * (m_bReverse ? 1 : 0), 0.0f);
    }
}
