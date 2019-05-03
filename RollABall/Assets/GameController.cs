using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score;
    public UIController uiControl;
    // Start is called before the first frame update
    void Start()
    {
        uiControl.ShowScore(score);
        uiControl.ShowClearMessage("");
    }
    public void AddScore(int amount)
    {
        score += amount;
        uiControl.ShowScore(score);
        if (score >= 10)
        {
            uiControl.ShowClearMessage("Game Clear");
            Debug.Log("Game Clear");
        }
    }
}
