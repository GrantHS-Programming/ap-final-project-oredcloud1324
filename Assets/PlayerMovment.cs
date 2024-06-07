using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    
    public float runSpeed = 40f;
    
    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetKeyDown (KeyCode.W)){
        jump = true;
        animator.SetBool("IsJumping", true);
        }
        
        if (Input.GetKeyDown (KeyCode.Mouse0)){
            
            animator.SetBool("IsAttacking", true);
        }
        
        else{
        animator.SetBool("IsAttacking", false);
        }
    }
    
    public void OnLanding (){
    animator.SetBool("IsJumping", false);
    }
    
    
    void FixedUpdate (){
    controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    jump = false;
    }
}
