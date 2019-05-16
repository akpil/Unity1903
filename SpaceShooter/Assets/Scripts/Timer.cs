using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float duration;
    private void OnEnable()
    {
        StartCoroutine(timeOut());
    }
    private IEnumerator timeOut()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
