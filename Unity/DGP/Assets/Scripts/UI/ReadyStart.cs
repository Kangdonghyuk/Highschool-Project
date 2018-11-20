using UnityEngine;
using System.Collections;

public class ReadyStart : MonoBehaviour {

    tk2dTextMesh m_cstk2dTextMesh;

	// Use this for initialization
	void Start () {

        m_cstk2dTextMesh = transform.GetComponent<tk2dTextMesh>();

        StartCoroutine("StartIE");

        m_cstk2dTextMesh.text = "READY";
        m_cstk2dTextMesh.Commit();

        transform.position = new Vector3(0.0f, 0.0f, -0.1f);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    IEnumerator OverText()
    {
        //transform.position = new Vector3(0.0f, 0.0f, -0.1f);
        m_cstk2dTextMesh.text = "TIMEUP";
        m_cstk2dTextMesh.Commit();

        while (true)
        {
            transform.Translate(0.0f, -2.0f * Time.deltaTime, 0.0f);

            yield return null;

            if (transform.position.y <= 0.0f)
            {
                break;
            }
        }
    }

    IEnumerator StartIE()
    {
        yield return new WaitForSeconds(1.5f);

        m_cstk2dTextMesh.text = "START";
        m_cstk2dTextMesh.Commit();

        while (true)
        {
            transform.Translate(0.0f, -2.0f * Time.deltaTime, 0.0f);
            yield return null;

            if (transform.position.y <= -0.3f)
            {
                break;
            }
        }

        while (true)
        {
            transform.Translate(0.0f,2.0f * Time.deltaTime, 0.0f);
            yield return null;

            if (transform.position.y >= 1.2f)
            {
                break;
            }
        }

        GameMNG.I.SetGameState(GameMNG.GAME_STATE.E_GAME_PLAY);

    }
}
