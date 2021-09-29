using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        bool isRunning = animator.GetBool("isRunning");
        bool forward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        bool isBacking = animator.GetBool("isBacking");
        bool back = Input.GetKey(KeyCode.S);

        //bool isClimbing = animator.GetBool("isClimbing");
        //bool wallClimb = Input.GetKey(KeyCode.Space);

        bool isJumping = animator.GetBool("isJumping");
        bool jump = Input.GetKeyDown(KeyCode.Space);



        if (forward)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isJumping",false);
            animator.SetBool("isIdle", false);
            

        }
        if (!forward && isRunning)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isIdle", true);
        }
        if (forward && jump)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
            animator.SetBool("isIdle", false);
        }
        if (jump)
        {
            print("wallah");
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isClimbing", false);
            animator.SetBool("isBacking", false);
        }
        if(!jump && isJumping)
        {
            print("not wallah");
            animator.SetBool("isIdle", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isClimbing", false);
            animator.SetBool("isBacking", false);

        }
        if (back)
        {
            animator.SetBool("isBacking", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isClimbing", false);
        }
        if(!back && isBacking)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isBacking", false);
            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isClimbing", false);
        }
        //if (wallClimb)
        //{
        //    animator.SetBool("isClimbing", true);
        //    animator.SetBool("isIdle", false);
        //    animator.SetBool("isJumping", false);
        //    animator.SetBool("isRunning", false);
        //    animator.SetBool("isBacking", false);
        //}
        //if (!wallClimb && isClimbing)
        //{
        //    animator.SetBool("isIdle", true);
        //    animator.SetBool("isClimbing", false);
        //    animator.SetBool("isJumping", false);
        //    animator.SetBool("isRunning", false);
        //    animator.SetBool("isBacking", false);
        //}
    }
}
