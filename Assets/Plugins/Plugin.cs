using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Plugin : MonoBehaviour
{
    [DllImport("Quiz DLL")]
    private static extern int ReturnRed(int a);
    [DllImport("Quiz DLL")]
    private static extern int ReturnBlue(int b);
    [DllImport("Quiz DLL")]
    private static extern int ReturnGreen(int c);


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ReturnRed(1));
        Debug.Log(ReturnBlue(2));
        Debug.Log(ReturnGreen(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
