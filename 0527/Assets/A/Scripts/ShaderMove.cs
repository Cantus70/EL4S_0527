using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaderMove : MonoBehaviour
{
    [SerializeField] private float threshold = 0f;

    public float FadeOutSpeed = 0.2f;
    public float FadeInSpeed = 0.2f;
    [SerializeField] bool FadeOutState = false;
    [SerializeField] bool FadeInState = false;

    [SerializeField] bool FadeOutFinish = true;
    [SerializeField] bool FadeInFinish = true;


    void Start()
    {
       
    }
    private void Update()
    {
        if (FadeOutState == true)
        {
            //Time.timeScale = 0f;
            FadeOut();
        }
        if (FadeInState == true)
        {
            //Time.timeScale = 0f;
            FadeIn();
        }
        //if (FadeOutState == false && FadeInState == false)
        //{
        //    Time.timeScale = 1f;
        //}
    }

    void FadeIn()
    {
        var material = GetComponent<SpriteRenderer>().material;

        threshold -= FadeInSpeed * Time.deltaTime;

        if (threshold <= -0.8)
        {
            FadeInState = false;
            FadeInFinish = true;
        }
        material.SetFloat("_treshhold", threshold);
    }
    void FadeOut()
    {
        var material = GetComponent<SpriteRenderer>().material;

        threshold += FadeOutSpeed * Time.deltaTime;
        if (threshold >= 1)
        {
            FadeOutState = false;
            FadeOutFinish = true;
        }
        material.SetFloat("_treshhold", threshold);
    }
    public bool GetFadeInFinish()
    {
        return FadeInFinish;
    }
    public bool GetFadeOutFinish()
    {
        return FadeOutFinish;
    }

    public void SetFadeInState(bool fadeinstate)
    {
        FadeInState = fadeinstate;
        FadeInFinish = false;
    }
    public void SetFadeOutState(bool fadeoutstate)
    {
        FadeOutState = fadeoutstate;
        FadeOutFinish = false;
    }
}