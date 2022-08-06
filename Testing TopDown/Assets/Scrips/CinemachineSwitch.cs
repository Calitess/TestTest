using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineSwitch : MonoBehaviour
{
    public GameObject AreaBox;
    public CinemachineVirtualCamera narrativeCam;
    public CinemachineVirtualCamera combatCam;
    public Animator animflame;



    // Start is called before the first frame update
    void Start()
    {
        narrativeCam.Priority = 1;
        combatCam.Priority = 0;

       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider AreaBox)
    {
        if (AreaBox.tag == "CombatArea")
        {
            Debug.Log("I have entered the combatarea");
            narrativeCam.Priority = 0;
            combatCam.Priority = 1;
            animflame.SetBool("InCombat", true);
        }

        
    }

    void OnTriggerExit(Collider AreaBox)
    {
            if (AreaBox.tag == "CombatArea")
            {
                Debug.Log("I have exited the combatarea");
                narrativeCam.Priority = 1;
                combatCam.Priority = 0;
                animflame.SetBool("InCombat", false);
            }
    }
}
