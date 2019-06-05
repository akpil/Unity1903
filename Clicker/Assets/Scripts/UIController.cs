using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
     
    [SerializeField]
    private Animator[] WindowsAnimArr;

    [SerializeField]
    private Text progressText;
    [SerializeField]
    private Image progressBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 이렇게 하면 안됨
        //for (int i = 0; i < WindowsAnimArr.Length-1; i++)
        //{
        //    WindowOpenButttons[i].onClick.AddListener(() => { Debug.Log(i); OpenWindow(i);  });
        //    WindowCloseButtons[i].onClick.AddListener(() =>
        //                                                {
        //                                                    Debug.Log(i);
        //                                                    CloseWindow(i);
        //                                                });
        //}
        
    }

    public void ShowProgress(float progress)
    {
        progressBar.fillAmount = progress;
        progressText.text = progress.ToString("P0");
    }

    public void OpenWindow(int id)
    {
        WindowsAnimArr[id].SetBool(AnimHash.WindowOpen, true);
    }
    public void CloseWindow(int id)
    {
        WindowsAnimArr[id].SetBool(AnimHash.WindowOpen, false);
    }
}
