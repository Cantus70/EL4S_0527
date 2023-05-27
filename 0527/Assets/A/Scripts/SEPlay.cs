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

    // �g���X�N���v�g����SE�̃N���b�v��p�ӂ��Ă��炤��
    public void SetPlaySE(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    // SEPlay���Ŋi�[���Ă�N���b�v��ԍ��Ŏ���
    public void SetPlaySE(int SEnumber)
    {
        audioSource.PlayOneShot(SEClips[SEnumber]);
    }

    // SEPlay���Ŋi�[���Ă�N���b�v�������Ō��߂�������Ŏ���
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
