using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreText;
    public Text MessageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowScore(int value)
    {
        ScoreText.text = "Score : " + value.ToString();
    }

    public void ShowMessage(string message)
    {
        MessageText.text = message;
    }
}
