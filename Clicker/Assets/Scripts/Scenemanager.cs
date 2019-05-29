using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    [SerializeField]
    private Button GameStartButton;
    [SerializeField]
    private GameObject touchToStartText;
    // Start is called before the first frame update
    void Start()
    {
        GameStartButton.onClick.AddListener(()=> { ShiftScene(1); });
        StartCoroutine(BlinkingText(.7f));
    }

    public void ShiftScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private IEnumerator BlinkingText(float countdown)
    {
        WaitForSeconds timeGap = new WaitForSeconds(countdown);
        while (true)
        {
            touchToStartText.SetActive(!touchToStartText.activeInHierarchy);
            yield return timeGap;
        }
    }
}
