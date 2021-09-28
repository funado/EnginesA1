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
        bool forward = Input.GetKey(KeyCode.W);
        

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", false);
            print("jump");

        }

        //else
        //{
        //    animator.SetBool("isIdle", true);
        //    animator.SetBool("isJumping", false);
        //    animator.SetBool("isRunning", false);
        //}
        //animator.SetBool("isIdle", true);
    }
}
