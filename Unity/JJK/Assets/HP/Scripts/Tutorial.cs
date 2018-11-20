using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
    public int m_nTurn = 0;
    public bool m_bClear = false;
    public bool m_bFiver = false;

    static Tutorial m_cInstance = null;
    float m_fTime = 0.0f;

    public static Tutorial I
    {
        get
        {
            if (m_cInstance == null)
            {
                m_cInstance = FindObjectOfType(typeof(Tutorial)) as Tutorial;

                if (m_cInstance == null)
                {
                    Debug.Log("Fail to get Tutorial Instance");
                    return null;
                }
            }

            return m_cInstance;
        }
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Ray stRay;
        RaycastHit stHit;

        switch (Tutorial.I.m_nTurn)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
                if (Input.GetMouseButtonDown(0))
                {
                    m_nTurn++;
                }
                break;
            case 8:
                if (m_bClear)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        m_nTurn++;
                    }
                }
                break;
            case 9:
                stRay = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(stRay, out stHit))
                {
                    if (Input.GetMouseButtonDown(0) && stHit.collider.name == "CardAllTurn")
                    {
                        m_nTurn++;
                    }
                }
                break;
            case 10:
            case 11:
                if (Input.GetMouseButtonDown(0))
                {
                    m_nTurn++;
                    m_bClear = false;
                }
                break;
            case 12:
                if (m_bClear)
                {
                    stRay = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(stRay, out stHit))
                    {
                        if (Input.GetMouseButtonDown(0) && stHit.collider.name == "CardRandomClear")
                        {
                            m_nTurn++;
                            m_bClear = false;
                        }
                    }
                }
                break;
            case 13:
                if (m_bClear)
                {
                    m_nTurn++;
                }
                break;
            case 14:
                if (Input.GetMouseButtonDown(0))
                {
                    m_nTurn++;
                    m_bFiver = true;
                    m_bClear = false;
                }
                break;
            case 15:
                if (m_bClear)
                {
                    m_nTurn++;
                }
                break;
            case 16:
                m_fTime += Time.deltaTime;

                if (m_fTime >= 1.0f)
                {
                    AutoFade.LoadLevel("5_Game", 1.0f, 1.0f, Color.black);
                }
                break;
        }
	}
}
