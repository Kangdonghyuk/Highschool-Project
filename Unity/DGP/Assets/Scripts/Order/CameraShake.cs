using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    Transform m_cTransform;

    Vector3 originPosition;
    Quaternion originRotation;
    Quaternion Rotation;

    float shake_decay;
    float shake_intensity;

    private static CameraShake m_Instance = null;
    public static CameraShake I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(CameraShake)) as CameraShake;

                if (null == m_Instance)
                {
                    Debug.Log("Fail to get CameraShake Instance");
                    return null;
                }
            }
            return m_Instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        m_cTransform = transform;

        Rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            Shake();

        if (shake_intensity > 0)
        {
            m_cTransform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            Rotation.Set(
            originRotation.x + Random.Range(-shake_intensity, shake_intensity) * 0.1f,
            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * 0.1f,
            originRotation.z + Random.Range(-shake_intensity, shake_intensity) * 0.1f,
            originRotation.w + Random.Range(-shake_intensity, shake_intensity) * 0.1f);
            m_cTransform.rotation = Rotation;//= new Quaternion(

            shake_intensity -= shake_decay;
        }
        else
        {
            originPosition.x = 0.0f;
            originPosition.y = 0.0f;
            originPosition.z = 0.0f;
            m_cTransform.position = originPosition;
            originRotation.x = 0.0f;
            originRotation.y = 0.0f;
            originRotation.z = 0.0f;
            originRotation.w = 0.0f;
            m_cTransform.rotation = originRotation;
        }
    }

    public void Shake()
    {
        originPosition.x = 0.0f;
        originPosition.y = 0.0f;
        originPosition.z = 0.0f;
        m_cTransform.position = originPosition;
        originRotation.x = 0.0f;
        originRotation.y = 0.0f;
        originRotation.z = 0.0f;
        originRotation.w = 0.0f;
        m_cTransform.rotation = originRotation;


        originPosition = m_cTransform.position;
        originRotation = m_cTransform.rotation;
        shake_intensity = 0.05f;
        shake_decay = 0.002f;
    }
}
