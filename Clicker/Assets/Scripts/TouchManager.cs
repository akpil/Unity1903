using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    private Ray GenerateRay(Vector3 ScreenVector)
    {
        Vector3 origin = mainCamera.ScreenToWorldPoint(new Vector3(ScreenVector.x,
                                                                    ScreenVector.y,
                                                                    mainCamera.nearClipPlane));

        Vector3 destination = mainCamera.ScreenToWorldPoint(new Vector3(ScreenVector.x,
                                                                ScreenVector.y,
                                                                mainCamera.farClipPlane));
        return new Ray(origin, destination - origin);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GenerateRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Timer effect = TouchEffectPool.instance.GetFromPool(0);
                    effect.transform.position = hit.point;
                    
                }
            }            
        }
#endif
        if (Touch())
        {

        }
#if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE_OSX
        
#endif
    }

    private bool Touch()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began)
                {
                    Ray ray = GenerateRay(t.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.gameObject == gameObject)
                        {
                            Timer effect = TouchEffectPool.instance.GetFromPool(0);
                            effect.transform.position = hit.point;
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
