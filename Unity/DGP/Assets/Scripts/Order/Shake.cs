using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
    int m_nShakeCount;
    float m_fNextAxccel;

    private static Shake m_Instance = null;
    public static Shake I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(Shake)) as Shake;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get Shake Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        m_nShakeCount = 0;
        m_fNextAxccel = 0;
    }

    // Update is called once per frame
    public void Update()
    {

        if (GameMNG.I.m_eGame_State == GameMNG.GAME_STATE.E_GAME_FEVER)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                PangMNG.I.Create(2);
            }

            if (m_nShakeCount == 0)
            {
                if (Mathf.Abs(Input.acceleration.y) > 0.5f)
                {
                    if (Input.acceleration.y > 0)
                        m_fNextAxccel = -0.5f;
                    else
                        m_fNextAxccel = 0.5f;
                    m_nShakeCount = 1;
                }
            }
            if (m_nShakeCount == 1)
            {
                if (m_fNextAxccel > 0)
                {
                    if (Input.acceleration.y < m_fNextAxccel)
                    {
                        m_fNextAxccel = -m_fNextAxccel;
                        m_nShakeCount = 2;
                    }
                }
                else
                {
                    if (Input.acceleration.y > m_fNextAxccel)
                    {
                        m_fNextAxccel = -m_fNextAxccel;
                        m_nShakeCount = 2;
                    }
                }
            }
            if (m_nShakeCount == 2)
            {
                if (m_fNextAxccel > 0)
                {
                    if (Input.acceleration.y < m_fNextAxccel)
                    {
                        m_fNextAxccel = -m_fNextAxccel;
                        PangMNG.I.Create(2);
                        Handheld.Vibrate();
                        m_nShakeCount = 0;
                    }
                }
                else
                {
                    if (Input.acceleration.y > m_fNextAxccel)
                    {
                        m_fNextAxccel = -m_fNextAxccel;
                        PangMNG.I.Create(2);
                        Handheld.Vibrate();
                        m_nShakeCount = 0;
                    }
                }
            }
        }
    }
}
