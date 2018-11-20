using UnityEngine;
using System.Collections;

public class csKg : MonoBehaviour {

    static float dt = 0.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        dt += Time.deltaTime;
        if (dt > 5.0f)
        {
            AutoFade.LoadLevel("2_Menu", 1.0f, 1.0f, Color.black);
        }
	}
}
