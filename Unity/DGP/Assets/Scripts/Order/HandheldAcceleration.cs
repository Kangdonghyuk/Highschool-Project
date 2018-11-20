using UnityEngine;
using System.Collections;

public class HandheldAcceleration : MonoBehaviour {

    Vector3 m_stGrivity;

	// Use this for initialization
	void Start () {
        m_stGrivity = new Vector3(0.0f, -3.81f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.acceleration.x > 0.0f)
        {
            m_stGrivity.y = 3.81f;
            Physics.gravity = m_stGrivity;
        }
        else
        {
            m_stGrivity.y = -3.81f;
            Physics.gravity = m_stGrivity;
        }
	}
}
