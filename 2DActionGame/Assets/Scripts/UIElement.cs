using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{
    [SerializeField]
    private Image Icon;
    [SerializeField]
    private Text TitleText, ContentsText;
    [SerializeField]
    private Button PurchaseButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitElement(Sprite icon, string title, string contents)
    {
        Icon.sprite = icon;
        Renew(title, contents);
    }
    public void Renew(string title, string contents)
    {
        TitleText.text = title;
        ContentsText.text = contents;
    }
    
}
