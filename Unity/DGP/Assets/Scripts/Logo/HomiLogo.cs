using UnityEngine;
using System.Collections;

public class HomiLogo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("ChangeScene", 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ChangeScene()
    {
        Application.LoadLevel("DGPMenu");
        System.GC.Collect();
    }
}
