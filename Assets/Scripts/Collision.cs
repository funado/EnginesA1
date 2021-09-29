using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        force = new Vector3(10, 10, 10);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnCollisionEnter(UnityEngine.Collision col)
    {
        if(col.gameObject.name == "mc")
        {
            print("bleh");
        }
    }
}
