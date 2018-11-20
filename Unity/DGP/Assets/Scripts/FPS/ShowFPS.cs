using UnityEngine;
using System.Collections;

public class ShowFPS : MonoBehaviour
{
    public UILabel label;

    int frameCount = 0;
    float nextUpdate = 0.0f;
    float fps = 0.0f;
    float updateRate = 4.0f;

    void Update()
    {
        frameCount++;
        if (Time.time > nextUpdate)
        {
            nextUpdate = Time.time + 1.0f / updateRate;
            fps = (float)frameCount * updateRate;
            frameCount = 0;
            label.text = string.Format("Fps:{0}", fps);
            //Debug.Log("a");
           // Debug.Log(nextUpdate);
        }
    }

}
