using UnityEngine;
using System.Collections;

public class CardAllTurn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void OnClick()
    {
        ItemMng.I.ICardAllTurn();
	}
}
