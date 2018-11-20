using UnityEngine;
using System.Collections;

public class CardTypeMng : MonoBehaviour {

    private static CardTypeMng m_Instance = null;
    public static CardTypeMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(CardTypeMng)) as CardTypeMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HFBCardTypeMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    string[] m_sCardTypeSpriteName = { "BOOK", "CAT", "CLOCK", "Cloud",  "EGG", "FROG", "HOUSE", "MOON",
                                     "MOUSE", "PUPPY", "RAIN", "SNAIL", "SNAKE", "STAR", "SUN", "TREE" };
    string[] m_sCardTypeSpriteNameK = { "책", "고양이", "시계", "구름", "달걀", "개구리", "집", "달", "쥐",
                                      "강아지", "비", "달팽이", "뱀", "별", "해", "나무"};
    string m_sCardBackTypeSpriteName = "CardBack";

    int m_nCardTypeMaxNum;

    int m_nMatrixCR;
    int[] m_nCardType;
    int[] m_nRCardType;
    int[] m_nTCardType;

    int m_nCardTypeMax;
    int m_nCardTypeNum;

    bool[] m_bCardUserType1;
    bool[] m_bCardUserType2;

    bool[] m_bCardTypeKEState;

	// Use this for initialization
	void Awake () {
        m_nCardTypeMaxNum = 16;

        m_nMatrixCR = 12;

        m_nCardType = new int[m_nMatrixCR / 2];
        m_nRCardType = new int[m_nMatrixCR];
        m_nTCardType = new int[m_nMatrixCR / 2];

        m_bCardUserType1 = new bool[m_nCardTypeMaxNum];
        m_bCardUserType2 = new bool[m_nCardTypeMaxNum];

        m_bCardTypeKEState = new bool[m_nCardTypeMaxNum];

        m_nCardTypeMax = 0;
        m_nCardTypeNum = 0;

        SetMatrixCR(2);
	}

    public void SetMatrixCR(int nCardTypeMax)
    {
        m_nCardTypeMax = nCardTypeMax;
        m_nCardTypeNum = 0;

        for (int _nMatxIndex = 0; _nMatxIndex < m_nMatrixCR / 2; _nMatxIndex++)
        {
            m_nCardType[_nMatxIndex] = -1;
            //m_nRCardType[_nMatxIndex] = -1;
            m_nTCardType[_nMatxIndex] = 0;
        }

        for (int _nMatxIndex = 0; _nMatxIndex < m_nMatrixCR; _nMatxIndex++)
        {
            m_nRCardType[_nMatxIndex] = -1;
        }

        for (int _nMatxIndex = 0; _nMatxIndex < m_nCardTypeMaxNum; _nMatxIndex++)
        {
            m_bCardUserType1[_nMatxIndex] = false;
            m_bCardUserType2[_nMatxIndex] = false;
            m_bCardTypeKEState[_nMatxIndex] = false;
        }

        int nCardIndex = 0;
        int nCardType = -1;

        while (m_nCardTypeNum < m_nCardTypeMax)
        {
            nCardIndex = Random.Range(0, m_nMatrixCR);
            if (m_nRCardType[nCardIndex] == -1)
            {
                bool _True = true;
                while (_True)
                {
                    nCardType = Random.Range(0, m_nCardTypeMaxNum);
                    if (m_bCardUserType1[nCardType] == false)
                    {
                        m_bCardUserType1[nCardType] = true;
                        m_nRCardType[nCardIndex] = nCardType;
                        m_nCardTypeNum += 1;
                        _True = false;
                    }
                }
            }
        }

        m_nCardTypeNum = 0;
        nCardIndex = 0;
        nCardType = 0;

        while (m_nCardTypeNum < m_nCardTypeMax)
        {
            nCardIndex = Random.Range(0, m_nMatrixCR);
            if (m_nRCardType[nCardIndex] == -1)
            {
                bool _True = true;
                while (_True)
                {
                    nCardType = Random.Range(0, m_nCardTypeMaxNum);
                    if (m_bCardUserType1[nCardType] == true && m_bCardUserType2[nCardType] == false)
                    {
                        m_bCardUserType2[nCardType] = true;
                        m_nRCardType[nCardIndex] = nCardType;
                        m_nCardTypeNum += 1;
                        _True = false;
                    }
                }
            }
        }
    }

    public int GetCardType(int nCardIndex)
    {
        return m_nRCardType[nCardIndex];
    }

    public string GetCardSpriteName(int nCardType)
    {
        if (nCardType == -1)
        {
            return m_sCardBackTypeSpriteName;
        }
        if (m_bCardTypeKEState[nCardType] == false)
        {
            m_bCardTypeKEState[nCardType] = true;
            return m_sCardTypeSpriteName[nCardType];
        }
        else
        {
            m_bCardTypeKEState[nCardType] = false;
            return m_sCardTypeSpriteNameK[nCardType];
        }
    }

    public string GetCardBackSpriteName()
    {
        return m_sCardBackTypeSpriteName;
    }

    public string GetFeverCardSpriteName(int nFeverCardType)
    {
        if (nFeverCardType == 0)
            return "STAR";
        else
            return "SUN";
    }

    public string GetFeverCardBackSpriteName()
    {
        return "CardBack";
    }

    // Update is called once per frame
    void Update()
    {
	
	}
}
