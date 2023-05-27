using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private static string ScoreData = "100";
    [SerializeField] Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "SCORE: " + ScoreData;
    }
    static public void SetScore(string score)
    {
        ScoreData = score;
    }
  
}
