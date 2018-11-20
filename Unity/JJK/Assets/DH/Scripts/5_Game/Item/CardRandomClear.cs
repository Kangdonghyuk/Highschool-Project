using UnityEngine;
using System.Collections;

public class CardRandomClear : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {
        if (Application.loadedLevelName == "5_Game")
            ItemMng.I.ICardRandomClear();
        else
            TutorialItemMng.I.ICardRandomClear();
	}
}
