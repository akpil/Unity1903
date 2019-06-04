using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private SpriteRenderer renderer;
    [SerializeField]
    private Sprite[] Sprites;
    private int currentIndex;
    private bool isFinish;

    // Start is called before the first frame update
    void Awake()
    {
        
        renderer = GetComponent<SpriteRenderer>();
        currentIndex = 0;
    }

    private void OnEnable()
    {
        isFinish = false;
        currentIndex = 0;
        renderer.sprite = Sprites[currentIndex];
    }

    public void ShowProgress(float prograss)
    {
        float percent = prograss * 100;
        float phaseShiftTarget = 20 * (1 + currentIndex);

        if (!isFinish && percent >= phaseShiftTarget)
        {
            currentIndex++;
            renderer.sprite = Sprites[currentIndex];
            
            if (currentIndex >= Sprites.Length - 1)
            {
                isFinish = true;
            }
        }

    }
}
