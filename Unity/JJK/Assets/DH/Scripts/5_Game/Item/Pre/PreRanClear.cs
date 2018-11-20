using UnityEngine;
using System.Collections;

public class PreRanClear : MonoBehaviour {

    public Transform m_cTarget;

    Vector3 m_stPos;

	// Use this for initialization
	void Start () {
        m_stPos = new Vector3(0.0f, 0.0f, -2.0f);

        transform.localScale = new Vector3(0.4f, 0.4f, 0.0f);

        m_cTarget = transform.parent.FindChild("CardRandomClear");
	}
	
	// Update is called once per frame
	void Update () {
        m_stPos.x = Mathf.SmoothStep(transform.localPosition.x, m_cTarget.localPosition.x, 0.2f);
        m_stPos.y = Mathf.SmoothStep(transform.localPosition.y, m_cTarget.localPosition.y, 0.2f);

        transform.localPosition = m_stPos;

        if (Mathf.Abs(m_cTarget.localPosition.x - m_stPos.x) < 5)
        {
            if (Mathf.Abs(m_cTarget.localPosition.y - m_stPos.y) < 5)
            {
                if (Application.loadedLevelName == "5_Game")
                    ItemMng.I.AddRanClearItem();
                else
                    TutorialItemMng.I.AddRanClearItem();

                Destroy(gameObject);
            }
        }
	
	}
}
