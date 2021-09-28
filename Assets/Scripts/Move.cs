using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private float movespeed;
    private float dirX, dirZ, dirY;

    public GameObject player;
    public float sensitivity;
    public Vector3 jump;
    private float jumpStrength;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        movespeed = 3.0f;
        jumpStrength = 2.0f;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
       dirX = Input.GetAxis("Horizontal") * movespeed;
       dirZ = Input.GetAxis("Vertical") * movespeed;


        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(jump * jumpStrength, ForceMode.Impulse);
        }
    }

    void OnCollisionStay()
    {
        grounded = true;
    }
    void OnCollisionExit()
    {
        grounded = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }
}   
