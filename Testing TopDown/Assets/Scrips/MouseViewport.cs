using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseViewport : MonoBehaviour
{
    
    public Camera mainCamera;

    void Start()
    {
        //mainCamera = this.GetComponent<Camera>();
    }

    void Update()
    {
        
            Debug.Log(mainCamera.ScreenToViewportPoint(Input.mousePosition));
        
    }
}


