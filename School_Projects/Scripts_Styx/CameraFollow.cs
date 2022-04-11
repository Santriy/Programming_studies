using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public GameObject animationRig;

    public float offsetX;
    private float negativeOffsetX;

    public float offsetY;
    public float timer;

    public float lookTimeUntilActivated;
    public float lookUpAmount;
    public float lookDownAmount;

    public float followSpeed;
    public bool followCam;

    private float interpolate;

    void Start()
    {
        negativeOffsetX = -offsetX;
        interpolate = followSpeed * Time.deltaTime;
    }

    void Update()
    {
        followCam = PlayerMovement.cameraFollowArea;
        timer += Time.deltaTime;

        if (Input.GetButton("Vertical"))
        {
                if (0 < Input.GetAxis("Vertical"))
                {
                    if (timer >= lookTimeUntilActivated) {LookUp(); }                  
                }
                else if (0 > Input.GetAxis("Vertical"))
                {
                    if (timer >= lookTimeUntilActivated) { LookDown(); }
                }
                else 
                {
                    return;
                }
            
            
        }
        else
        {
            timer = 0f;
        }


        if(PlayerMovement.facingLeft)
        {
            offsetX = negativeOffsetX;
        }
        else
        {
            offsetX = -negativeOffsetX;
        }
       

        if(!followCam)
        {
            SteadyCam();
        }
        if(followCam)
        {
            FollowCam();
        }
    }

    void LookUp()
    {
        Vector3 position = transform.position;
        position.x = (transform.position.x);
        position.y = Mathf.Lerp(transform.position.y, transform.position.y + lookUpAmount, interpolate);
        transform.position = position;


    }

    void LookDown()
    {
        Vector3 position = transform.position;
        position.x = (transform.position.x);
        position.y = Mathf.Lerp(transform.position.y, transform.position.y - lookDownAmount, interpolate);
        transform.position = position;

    }

    void SteadyCam()
    {        
        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, player.transform.position.x + offsetX, interpolate);
        position.y = Mathf.Lerp(transform.position.y, PlayerMovement.storedYPos + offsetY, interpolate);
        transform.position = position;
    }

    void FollowCam()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, player.transform.position.x + offsetX, interpolate);
        position.y = Mathf.Lerp(transform.position.y, player.transform.position.y + offsetY, interpolate);
        transform.position = position;
    }
}
