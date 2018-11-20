using UnityEngine;
using System.Collections;

public class RankingDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
	}
}
