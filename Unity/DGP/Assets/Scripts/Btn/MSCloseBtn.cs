using UnityEngine;
using System.Collections;

public class MSCloseBtn : MonoBehaviour
{

    Store m_csStore;

    // Use this for initialization
    void Start()
    {
        m_csStore = transform.parent.GetComponent<Store>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        SoundMNG.I.PlaySound(SoundMNG.SOUND_KIND.E_SOUND_PANG);
        m_csStore.OnOffStore();
    }
}
