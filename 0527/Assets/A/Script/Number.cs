using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    int m_Number;

    bool m_calcNumber = false;

    SpriteRenderer m_Renderer;

    [SerializeField] Sprite[] Numbers;

    void Start()
    {
        if (!m_calcNumber)
        {
            m_Number = Random.Range(1, 10); // ‚P`‚X‚Ì”ÍˆÍ
            Debug.Log(m_Number);
        }
        m_Renderer = GetComponent<SpriteRenderer>();
        m_Renderer.sprite = Numbers[m_Number];
    }

    public int GetNumber()
    {
        return m_Number;
    }

    public void SetNumber(int number,bool keisan = true)
    {
        m_Number = number;
        m_calcNumber = keisan;
    }
}
