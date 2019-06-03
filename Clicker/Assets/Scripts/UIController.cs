using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static int WindowOpen = Animator.StringToHash("IsOpened");    
    [SerializeField]
    private Animator[] WindowsAnimArr;

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

    public void OpenWindow(int id)
    {
        WindowsAnimArr[id].SetBool(WindowOpen, true);
    }
    public void CloseWindow(int id)
    {
        WindowsAnimArr[id].SetBool(WindowOpen, false);
    }
}
