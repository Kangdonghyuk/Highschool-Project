using UnityEngine;
using System.Collections;

public class csFont : MonoBehaviour
{

    UISprite FontSprite = null;
    public bool AlphaD = true;
    public bool AlphaU = false;
    public bool m_bFontSprite = false;
    // Use this for initialization
    void Start()
    {
        FontSprite = GameObject.Find("FontSprite").GetComponent<UISprite>();
    }

    // Update is called once per frame
    void Update()
    {

        if (AlphaD == true)
        {
            AlphaDown();
        }
        if (AlphaU == true)
        {
            AlphaUp();
        }
        if (FontSprite.alpha > 1.0f)
        {
            AlphaD = true;
            AlphaU = false;
        }
        if (FontSprite.alpha < 0.0f)
        {
            AlphaD = false;
            AlphaU = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            m_bFontSprite = true;
        }
        if (m_bFontSprite == true)
        {
            AlphaD = false;
            AlphaU = true;
        }
    }

    void AlphaUp()
    {
        FontSprite.alpha += 1.5f * Time.deltaTime;
    }

    void AlphaDown()
    {
        FontSprite.alpha -= 1.5f * Time.deltaTime;
    }
}