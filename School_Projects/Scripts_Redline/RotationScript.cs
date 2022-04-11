using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float smooth = 5f;
    public float tiltAngle = 15f;
    
    
    Quaternion startRot;

    private void Start()
    {        
        startRot = transform.rotation;
    }
    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");

        if (Input.GetButton("Horizontal"))
        {
            float tiltAroundZ = Input.GetAxis("Horizontal") * -tiltAngle;

            Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, startRot, Time.deltaTime * smooth);
    }
}
