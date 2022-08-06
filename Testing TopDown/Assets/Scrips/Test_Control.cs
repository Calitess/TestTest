using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Control : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;

    public Vector2 moveInput;

    public LayerMask Ground;
    public Transform groundPoint;
    public bool isGrounded;

    public Animator anim;

    public GameObject AreaCombat;
    public bool inCombatArea = false;

    public Camera mainCamera;
    public Vector3 mousePoint;

    public GameObject Flame;
   


    // Start is called before the first frame update
    void Start()
    {
        Flame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mousePoint = mainCamera.ScreenToViewportPoint(Input.mousePosition);

        //We wanna normalize the direction of the movements to make sure its not funkyy
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        //This is to check the velocity of the rigibbody a.k.a player, according to what the player inputs
        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);

        //This is to set the MoveSpeed float inside the animator to be the same as the one that the player input
        anim.SetFloat("MoveSpeed", theRB.velocity.magnitude);

        //Check if player is on ground or not. To not allow player to jump in air
        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .5f, Ground))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        //Using Project Settings to define Jump button. This is to check if player presses that button while being on greound
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f, jumpForce, 0f);
        }

        anim.SetBool("OnGround", isGrounded);

        if (inCombatArea == false)
        {
            Flame.SetActive(false);
            //This is to check which direction players are going to change the sprites
            if (Input.GetAxis("Vertical") > 0.1f)
            {
                anim.SetBool("MoveBack", true);
            }
            else
            {
                anim.SetBool("MoveBack", false);
            }

            if (Input.GetAxis("Vertical") < -0.1f)
            {
                anim.SetBool("MoveFront", true);
            }
            else
            {
                anim.SetBool("MoveFront", false);
            }

            if (Input.GetAxis("Horizontal") > 0.1f)
            {
                anim.SetBool("MoveRight", true);
            }
            else
            {
                anim.SetBool("MoveRight", false);
            }

            if (Input.GetAxis("Horizontal") < -0.1f)
            {
                anim.SetBool("MoveLeft", true);
            }
            else
            {
                anim.SetBool("MoveLeft", false);
            }

        }

        if (inCombatArea == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Flame.SetActive(true);
                Debug.Log("Flaming");
            }
            else if (Input.GetMouseButtonUp(0))
            { 
                Flame.SetActive(false);
                Debug.Log("Not Flaming");
            }
            

            if (mousePoint.x >= 0 && mousePoint.x <= 0.333 && mousePoint.y >= 0 && mousePoint.y <= 1)
            {
                anim.SetBool("MoveLeft", true);

                Debug.Log("I am looking left");
            }
            else
            {
                anim.SetBool("MoveLeft", false);
            }

            if (mousePoint.x >= 0.666 && mousePoint.x <= 1 && mousePoint.y >= 0 && mousePoint.y <= 1)
            {
                anim.SetBool("MoveRight", true);
                
                Debug.Log("I am looking rightd");
            }
            else
            {
                anim.SetBool("MoveRight", false);
            }

            if (mousePoint.x >= 0.333 && mousePoint.x <= 0.666 && mousePoint.y >= 0 && mousePoint.y <= 0.51)
            {
                anim.SetBool("MoveFront", true);
                Debug.Log("I am looking Front");
            }
            else
            {
                anim.SetBool("MoveFront", false);
            }

            if (mousePoint.x >= 0.333 && mousePoint.x <= 0.666 && mousePoint.y >= 0.5 && mousePoint.y <= 1)
            {
                anim.SetBool("MoveBack", true);

                Debug.Log("I am looking Back");
            }
            else
            {
                anim.SetBool("MoveBack", false);
            }

        }
            //Pause the animation when player dont move
            if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
            {
                anim.speed = 0;
            }
            else
            {
                anim.speed = 1;

            }
        

        
    }

    void OnTriggerStay(Collider AreaCombat)
    {
        if (AreaCombat.tag == "CombatArea")
        {
            inCombatArea = true;
        }

    }

    void OnTriggerExit(Collider AreaCombat)
    {
        if (AreaCombat.tag == "CombatArea")
        {
            inCombatArea = false;
        }

    }
}
