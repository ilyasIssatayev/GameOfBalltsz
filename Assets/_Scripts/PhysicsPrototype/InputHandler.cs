using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
  
    void Update()
    {
        int touchCount = Input.touchCount;

        for(int i=0;i<touchCount;i++)
        {
            Touch touch = Input.GetTouch(i);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(touch.position);
            worldPos.z = 0;
            Debug.Log(worldPos);
        }
    }
}
