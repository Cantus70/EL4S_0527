using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OperateType
{
    Plus = 0,
    Minus,
    Multiplication, // Š|‚¯ŽZ
    Division        // Š„‚èŽZ
}


public class Operator : MonoBehaviour
{
    [SerializeField]
    OperateType m_Operate;
    SpriteRenderer m_Renderer;



    [SerializeField] Sprite[] Operates;

    void Start()
    {
        Debug.Log(m_Operate);

        m_Renderer = GetComponent<SpriteRenderer>();
        m_Renderer.sprite = Operates[(int)m_Operate];
    }

    public OperateType GetOperate()
    {
        return m_Operate;
    }
}
