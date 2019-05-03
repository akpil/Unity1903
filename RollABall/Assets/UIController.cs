using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoreText, clearText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ShowScore(int score)
    {
        scoreText.text = "Score : " + score.ToString();
    }
    public void ShowClearMessage(string message)
    {
        clearText.text = message;
    }

}
