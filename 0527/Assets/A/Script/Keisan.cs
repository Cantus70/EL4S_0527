using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HaveNumber
{
    none = 0,
    haveNumber,
    haveOperator
}

public class Keisan : MonoBehaviour
{
    Number haveOldNumber;
    Number haveNewNumber;
    Operator haveOperator;

    int keisanKekka;

    [SerializeField]
    GameObject Number;

    int m_ScoreCount;

    private void Start()
    {
        m_ScoreCount = 0;
    }


    public void SetNumbers(GameObject gameObject,HaveNumber haveNumber)
    {
        switch (haveNumber)
        {
            case HaveNumber.none:
                haveOldNumber = gameObject.GetComponent<Number>();
                break;

                case HaveNumber.haveNumber:
                haveOperator = gameObject.GetComponent<Operator>();
                break;

            case HaveNumber.haveOperator:
                haveNewNumber = gameObject.GetComponent<Number>();

                // ŒvZ‚·‚é
                KeisanKekka();
                break;
        }
    }

    public void Relese()
    {
        haveOldNumber = null;
        haveOperator = null;
        haveNewNumber = null;
    }

    void KeisanKekka()
    {
        // ‰‰Zq–ˆ‚É•Ï‚¦‚é
        switch(haveOperator.GetOperate())
        {
            case OperateType.Plus:
                keisanKekka = haveOldNumber.GetNumber() + haveNewNumber.GetNumber();
                break;

            case OperateType.Minus:
                keisanKekka = haveOldNumber.GetNumber() - haveNewNumber.GetNumber();
                break;

            case OperateType.Multiplication:
                keisanKekka = haveOldNumber.GetNumber() * haveNewNumber.GetNumber();
                break;

            case OperateType.Division:
                keisanKekka = haveOldNumber.GetNumber() / haveNewNumber.GetNumber();
                break;
        }

        // ŒvZŒ‹‰Ê‚ğ‚P‚O‚ÅŠ„‚Á‚Ä—]‚è‚ªo‚È‚¢‚È‚ç
        if(keisanKekka % 10 == 0)
        {
            // ƒXƒRƒA‰ÁZ
            m_ScoreCount++;

            Score.SetScore(m_ScoreCount.ToString());
        }
        else
        {
            // ”š”­¶
            // ‚P‚O‚ÌˆÊ
            int zyuu = keisanKekka / 10;
            GameObject newNumber;
            if (zyuu != 0)
            {
                newNumber = Instantiate(Number, new Vector2(-1.0f, 2.0f), Quaternion.identity);
                newNumber.GetComponent<Number>().SetNumber(Math.Abs(zyuu));
            }
                           

            // ‚P‚ÌˆÊ
            int ichi = keisanKekka % 10;
            newNumber = Instantiate(Number, new Vector2(1.0f, 2.0f), Quaternion.identity);
            newNumber.GetComponent<Number>().SetNumber(Math.Abs(ichi));
        }
    }
}