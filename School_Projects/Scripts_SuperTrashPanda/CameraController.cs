using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;  
    public Transform playerT;
    public float offsetX = -5;  
    public float offsetZ = 0;  
    public float maximumDistance = 2;  
    public float playerVelocity = 10;

    int degrees = 0;

    private float movementX;
    private float movementZ;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movementX = ((player.transform.position.x + offsetX - transform.position.x)) / maximumDistance;
        movementZ = ((player.transform.position.z + offsetZ - transform.position.z)) / maximumDistance;
        transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), 0, (movementZ * playerVelocity * Time.deltaTime));

        transform.LookAt(player.transform.position);


        if(Input.GetMouseButton (1))
        {
            degrees = 10;
            transform.RotateAround(playerT.position, Vector3.up, Input.GetAxis ("Mouse X") * degrees);
        }
        if (!Input.GetMouseButton (1))
        {
            transform.RotateAround(playerT.position, Vector3.up, degrees * Time.deltaTime);
        }
        else
        {
            degrees = 0;
        }

    }

    private void LateUpdate()
    {
      
    }
}