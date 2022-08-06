using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mainCamera.ScreenPointToRay(Input.mousePosition));
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            //transform.position = raycastHit.point;
        }
    }
}
