using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;

    public Animator animator;

    float horizontalMove = 0f;
    bool jump = false;
    bool block = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            animator.SetBool("Grounded", false);
        }

        if (Input.GetButtonDown("Block"))
        {
            block = true;
        }
        else if (Input.GetButtonUp("Block"))
        {
            block = false;
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("Grounded", true);
    }

    public void OnBlocking(bool isBlocking)
    {
        animator.SetBool("IsBlocking", isBlocking);
    }



    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, block, jump);
        jump = false;
    }


}