using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSway : MonoBehaviour
{
    public float timer;
    public float swaySpeedX = 0.5f;
    public float swaySpeedY = 0.5f;
    public float swayTime = 2f;

    public bool platformMoveHorizontally;
      
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= swayTime)
        { 
            swaySpeedY = -swaySpeedY; timer = 0f;
            swaySpeedX = -swaySpeedX; timer = 0f;
        }

        if(platformMoveHorizontally)
        {
            transform.Translate(swaySpeedX * Time.deltaTime, 0, 0);

        }
        else
        {
            transform.Translate(0, swaySpeedY * Time.deltaTime, 0);
            platformMoveHorizontally = false;
        }
    }
}
