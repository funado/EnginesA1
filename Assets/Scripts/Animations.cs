using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        foreach(AnimationState state in anim)
        {
            state.speed = 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
