using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    //�J�E���g�_�E��
    public float countdown = 5.0f;

    //���Ԃ�\������Text�^�̕ϐ�
    public Text timeText;

    [SerializeField] string SceneName;

    // Update is called once per frame
    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        countdown -= Time.deltaTime;

        //���Ԃ�\������
        timeText.text = "Time�F" + countdown.ToString("f3");

        //countdown��0�ȉ��ɂȂ����Ƃ�
        if (countdown <= 0)
        {
            timeText.text = "�V�[���J��";
            SceneManager.LoadScene(SceneName);
        }
    }
}