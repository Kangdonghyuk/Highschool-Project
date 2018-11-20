using UnityEngine;
using System.Collections;

public class PangPicking : MonoBehaviour
{
    RaycastHit m_stRaycastHit; // �浹�� ������Ʈ  
    Ray m_stRay; // Ray

    GameObject m_cDPang; // �ι�����

    FeverPang m_csFeverPang;

    WaitForSeconds m_cWaitForSecons; // �ڷ�ƾ

    Vector3 m_stMousePos; // ���콺��ǥ

    bool m_bPangCheckState; // ������ ���ִ��� üũ
    bool m_bFeverPangCheckState;
    //bool m_bMobCheckState;
    bool m_bLongPangCheckState; // ������ 2�����ִ��� üũ


    // Use this for initialization
    void Start()
    {
        m_cWaitForSecons = new WaitForSeconds(0.3f);

        m_csFeverPang = GameObject.Find("FeverPang").GetComponent<FeverPang>();
        if (m_csFeverPang == null)
            Debug.Log("NULL");

        m_bPangCheckState = false;
        m_bLongPangCheckState = false;
        m_bFeverPangCheckState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMNG.I.m_eGame_State == GameMNG.GAME_STATE.E_GAME_PLAY ||
            GameMNG.I.m_eGame_State == GameMNG.GAME_STATE.E_GAME_FEVER)
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                m_stRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(m_stRay, out m_stRaycastHit, 10) == true)
                {
                    if (m_stRaycastHit.transform.tag == "PANG")
                    {
                        m_bPangCheckState = true;
                        m_bLongPangCheckState = false;
                        m_stMousePos = Input.mousePosition;
                        PangMNG.I.Down(m_stRaycastHit.transform.gameObject);

                        StartCoroutine("LongClick");
                    }
                    else if (m_stRaycastHit.transform.tag == "FEVERPANG")
                    {
                        m_bFeverPangCheckState = true;
                        m_csFeverPang.Down();
                    }
                    else if (m_stRaycastHit.transform.tag == "PANGBOOM")
                    {
                        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_BOOM);
                        PangMNG.I.RemoveBoom(m_stRaycastHit.transform.gameObject);
                    }
                    /*else if (m_stRaycastHit.transform.tag == "MOB")
                    {
                        EnemyMNG.I.HeatMob(m_stRaycastHit.transform.gameObject, 1);
                    }*/
                }
            }
           /* else if (Input.GetMouseButton(0) == true)
            {
                m_stRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(m_stRay, out m_stRaycastHit, 10) == true)
                {
                    if (m_stRaycastHit.transform.tag == "MOB")
                    {
                          EnemyMNG.I.HeatMob(m_stRaycastHit.transform.gameObject, 1);
                          m_bMobCheckState = true;
                    }
                }
            }*/
            else if (Input.GetMouseButtonUp(0) == true)
            {
                if (m_bFeverPangCheckState == true)
                {
                    m_csFeverPang.Up();
                    m_bFeverPangCheckState = false;
                }

                if (m_bPangCheckState == true)
                {
                    if (m_bLongPangCheckState == true)
                    {
                        PangMNG.I.DUp();
                        m_bLongPangCheckState = false;
                    }

                    m_bPangCheckState = false;
                    PangMNG.I.Up();
                }
            }
        }
    }

    // �� ������ �־��� üũ(������ �־��ٸ� �ֺ��� �߰� ����)
    IEnumerator LongClick()
    {
        yield return m_cWaitForSecons;

        if (m_stMousePos == Input.mousePosition && m_bPangCheckState == true)
        {
            m_cDPang = PangCheckMNG.I.GetAroundPang(PangMNG.I.m_cCheckPang[0]);
            if (m_cDPang != null)
            {
                Handheld.Vibrate();
                PangMNG.I.DDown(m_cDPang);
            }
            //PangMNG.I.DDown(PangCheckMNG.I.GetAroundPang(PangMNG.I.m_cCheckPang[0]));
            m_bLongPangCheckState = true;
        }

        StopCoroutine("LongClick");
    }
}
