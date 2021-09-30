using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private float movespeed;
    private float dirX, dirZ;
    private float jumpStrength;

    private float rotX, rotY = 0.0f;

    public GameObject player;
    public float sensitivity;
    public Vector3 jump;
    public bool grounded;

    public float msens = 200.0f;
    public float clamp = 80.0f;

    public float climbSpeed = 5.0f;
    public float sticktowall = 1.0f;
    public float range = 1.0f;
    public float gravity;


    // Start is called before the first frame update
    void Start()
    {
        movespeed = 50.0f;
        jumpStrength = 2.0f;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.5f, 0.0f);

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        
        
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

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotX += mouseY * msens * Time.deltaTime;
        rotY += mouseX * msens * Time.deltaTime;


        rotX = Mathf.Clamp(rotX, -clamp, clamp);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        //WallClimb();
        if (Input.GetKey("escape"))
        {
            Application.Quit();
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
        //rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
        //rb.velocity = rb.velocity * rb.velocity.y;
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity += transform.forward * Time.deltaTime * 10.0f;
            rb.velocity += transform.up * Time.deltaTime * gravity;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * Time.deltaTime * movespeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * Time.deltaTime * movespeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * Time.deltaTime * movespeed;
        }
    }

    public void WallClimb()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Wall")
            {
                gravity = 1f;
                if (Input.GetKey(KeyCode.Space))
                {
                    print("wc");
                    //transform.position += transform.forward * Time.deltaTime * sticktowall;
                    //transform.position += transform.up * Time.deltaTime * climbSpeed;
                    rb.velocity += transform.up * Time.deltaTime * climbSpeed * 2.0f;
                }
            }
        }
        else
        {
            //print("not wc");
            gravity = -3.81f;
        }
    }
}   
