using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaAnimation : MonoBehaviour
{

    Animator lavaAnimator;
    // Start is called before the first frame update
    void Start()
    {
        lavaAnimator = GetComponent<Animator>();
        lavaAnimator.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
