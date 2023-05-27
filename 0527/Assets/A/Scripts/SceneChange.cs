using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string SceneName;
    private GameObject SEPlayer;
    GameObject shaderMove;
    bool ButtonState = false;


    // Start is called before the first frame update
    void Start()
    {
        SEPlayer = FindObjectOfType<SEPlay>().gameObject;
        shaderMove = FindObjectOfType<ShaderMove>().gameObject;
        shaderMove.GetComponent<ShaderMove>().SetFadeInState(true);
    }

    // Update is called once per frame
    void Update()
    {
        FadeStart();
        if (ButtonState == true && shaderMove.GetComponent<ShaderMove>().GetFadeOutFinish() == true)
        {
            LoadScene();
        }
    }
    public void FadeStart()
    {
        if (shaderMove.GetComponent<ShaderMove>().GetFadeInFinish() == true)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                SEPlayer.GetComponent<SEPlay>().SetPlaySE("ButtonClick");

                shaderMove.GetComponent<ShaderMove>().SetFadeOutState(true);
                ButtonState = true;
            }
        }    
    }

    public void ButtonFadeStart()
    {
        if (shaderMove.GetComponent<ShaderMove>().GetFadeInFinish() == true)
        {
            SEPlayer.GetComponent<SEPlay>().SetPlaySE("ButtonClick");

            shaderMove.GetComponent<ShaderMove>().SetFadeOutState(true);
            ButtonState = true;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
