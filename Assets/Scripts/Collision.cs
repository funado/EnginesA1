using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 force;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        force = new Vector3(10, 10, 10);
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //print("collision script working");
    }

   void OnTriggerEnter(Collider col)
    {

        //print("colliding");
        if (col.gameObject.CompareTag("Box"))
        {
            //var playerRenderer = player.GetComponent<Renderer>();
            //playerRenderer.material.SetColor("_Color", Color.red);
            col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            
            print("Set color red");
            
        }
    }
}
