using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private SpriteRenderer renderer;
    [SerializeField]
    private Sprite[] Sprites;
    private int currentIndex;

    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        currentIndex = 0;
    }

    public void ShowProgress(float current, float max)
    {
        float progressRate =  current / max;
        float progressBase = 1f / Sprites.Length;

        if (progressRate >= 1)
        {
            gameObject.SetActive(false);
        }

        if ((currentIndex + 1) * progressBase < progressRate && progressRate < 1)
        {
            currentIndex++;
            renderer.sprite = Sprites[currentIndex];
        }
    }
}
