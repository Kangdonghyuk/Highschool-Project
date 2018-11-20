using UnityEngine;
using System.Collections;

public class csBackLight : MonoBehaviour {

    UISprite BackLight1 = null;
    UISprite BackLight2 = null;
    Light light = null;

    static float dt = 0.0f;
	// Use this for initialization
	void Start () {

        BackLight1 = GameObject.Find("BackLight1").GetComponent<UISprite>();
        BackLight2 = GameObject.Find("BackLight2").GetComponent<UISprite>();
        light = GameObject.Find("Directional light").GetComponent<Light>();

        BackLight1.alpha = 0.0f;
        BackLight2.alpha = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        dt += Time.deltaTime;

        if (dt >= 2.5f)
        {
            BackLight1.alpha += 1.0f * Time.deltaTime;
            
            if (light.intensity >= 1.5f)
            {
                light.intensity -= 0.3f;
            }
        }
        if (dt >= 3.0f)
        {
            BackLight2.alpha = 1.0f;
        }
        if (dt >= 3.8f)
        {
            BackLight1.alpha -= 2.0f * Time.deltaTime;
            
            if (light.intensity <= 8.0f)
            {
                light.intensity += 0.6f;
            }
        }

        if (Input.GetMouseButton(0))
        {
            AutoFade.LoadLevel("2_Menu", 1.0f, 1.0f, Color.black);
        }
	}
}


