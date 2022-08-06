using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public GameObject Flame;
    public GameObject FireOnMe;

    public bool onFire;

    // Start is called before the first frame update
    void Start()
    {
        FireOnMe.SetActive(false);
        onFire = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (Flame.activeInHierarchy == true && onFire == true)
       {
            
                FireOnMe.SetActive(true);
                Debug.Log("Its burning AAAAAAAAaaaaaaaaaaaaa");
            
        }
       else if (Flame.activeInHierarchy == false || onFire == false)
        {
           
                FireOnMe.SetActive(false);
            
        }

       

    }

    void OnTriggerStay(Collider Flame)
    {
        if (Flame.tag == "Flame") 
        {
           onFire = true;
            
        }

    }

    void OnTriggerExit(Collider Flame)
    {
        
           
        
        onFire = false;
            
      
        
    }
        
}
