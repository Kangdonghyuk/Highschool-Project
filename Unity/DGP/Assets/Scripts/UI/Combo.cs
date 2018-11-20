using UnityEngine;
using System.Collections;

public class Combo : MonoBehaviour
{

    tk2dTextMesh m_csCombotk2dTextMesh; // tk2dTextMesh ��ũ��Ʈ (Combo)
    tk2dTextMesh m_csComboCounttk2dTextMesh; // tk2dTextMesh ��ũ��Ʈ (Count)

    Transform m_cTransform; // �ڽ��� Transform

    Color m_stColor; // ����

    public int m_nComboCount; // ���� �޺� ī��Ʈ

    // Use this for initialization
    void Start()
    {
        m_cTransform = GetComponent<Transform>();

        m_csCombotk2dTextMesh = GetComponent<tk2dTextMesh>();
        m_csComboCounttk2dTextMesh = m_cTransform.FindChild("ComboCount").GetComponent<tk2dTextMesh>();

        m_stColor = new Color(1.0f, 0.0f, 0.0f);
        m_stColor.a = 0.0f;

        m_nComboCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMNG.I.m_eGame_State != GameMNG.GAME_STATE.E_GAME_PAUSE)
        {
            if (m_stColor.a != 0.0f)
            {
                if (KDHManager.I.m_bComboTimeUpState == false)
                    m_stColor.a -= 0.01f;
                else if (KDHManager.I.m_bComboTimeUpState == true)
                    m_stColor.a -= 0.005f;

                m_csCombotk2dTextMesh.color = m_stColor;
                m_csComboCounttk2dTextMesh.color = m_stColor;

                m_csCombotk2dTextMesh.Commit();
                m_csComboCounttk2dTextMesh.Commit();

                if (m_stColor.a <= 0.01f)
                {
                    m_nComboCount = 0;
                    m_stColor.a = 0.0f;
                }
            }
        }
    }

    // ���޹��� ���ڸ�ŭ�޺� ��� �� ��ġ ����
    public void AddCombo(int nAddCombo, Vector3 stPos)
    {
        stPos.z = -0.01f;
        m_cTransform.position = stPos;

        m_nComboCount += nAddCombo;

        m_stColor.a = 1.0f;

        m_csCombotk2dTextMesh.color = m_stColor;
        m_csComboCounttk2dTextMesh.color = m_stColor;

        m_csComboCounttk2dTextMesh.text = m_nComboCount.ToString();
        m_csCombotk2dTextMesh.Commit();
        m_csComboCounttk2dTextMesh.Commit();
    }

    public int GetCombo()
    {
        return m_nComboCount;
    }
}
