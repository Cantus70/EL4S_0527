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

                // 計算する
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
        // 演算子毎に変える
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

        // 計算結果を１０で割って余りが出ないなら
        if(keisanKekka % 10 == 0)
        {
            // スコア加算
            m_ScoreCount++;

            Score.SetScore(m_ScoreCount.ToString());
        }
        else
        {
            // 数字発生
            // １０の位
            int zyuu = keisanKekka / 10;
            GameObject newNumber;
            if (zyuu != 0)
            {
                newNumber = Instantiate(Number, new Vector2(-1.0f, 2.0f), Quaternion.identity);
                newNumber.GetComponent<Number>().SetNumber(Math.Abs(zyuu));
            }
                           

            // １の位
            int ichi = keisanKekka % 10;
            newNumber = Instantiate(Number, new Vector2(1.0f, 2.0f), Quaternion.identity);
            newNumber.GetComponent<Number>().SetNumber(Math.Abs(ichi));
        }
    }
}