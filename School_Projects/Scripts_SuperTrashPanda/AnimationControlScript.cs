using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlScript : MonoBehaviour
{
    private Animator myAnimator;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float walkVal = Input.GetAxis("Vertical");

        if (Input.GetButton("Vertical"))
        {
            myAnimator.SetFloat("WalkValue", walkVal);
        }
        else
        {
            myAnimator.SetFloat("WalkValue", 0f);
        }

        if(Input.GetButton("Fire1"))
        {
            myAnimator.SetBool("Throw", true);
        }
        else
        {
            myAnimator.SetBool("Throw", false);
        }

    }
}
