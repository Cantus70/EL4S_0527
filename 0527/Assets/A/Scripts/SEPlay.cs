using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPlay : MonoBehaviour
{
    [SerializeField] private AudioClip[] SEClips;
    AudioSource audioSource;
    private AudioClip SE;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // 使うスクリプト側でSEのクリップを用意してもらう版
    public void SetPlaySE(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    // SEPlay内で格納してるクリップを番号で取る版
    public void SetPlaySE(int SEnumber)
    {
        audioSource.PlayOneShot(SEClips[SEnumber]);
    }

    // SEPlay内で格納してるクリップを自分で決めた文字列で取る版
    public void SetPlaySE(string audioClip)
    {
        for (int i = 0; i < SEClips.Length; i++)
        {
            if (audioClip == SEClips[i].name)
            {
                SE = SEClips[i];
            }
        }
        audioSource.PlayOneShot(SE);
    }

    public void SetSEVolume(float Volume)
    {
        audioSource.volume = Volume;
    }
}
