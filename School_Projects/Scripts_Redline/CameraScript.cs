using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Transform target; 
    public float offsetX, offsetY, offsetZ;
    public float boostOffsetZ;
    public float delay;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x + offsetX, player.position.y + offsetY, player.position.z + offsetZ);
        //transform.position = Vector3.Lerp(transform.position, newPos, delay * Time.deltaTime);
        transform.LookAt(target);

        //if (Input.GetButton("Jump"))
        {
            //Vector3 boostCam = new Vector3(player.position.x + offsetX, player.position.y + offsetY, player.position.z + offsetZ + boostOffsetZ);
            //transform.position = Vector3.Lerp(transform.position, boostCam, delay * Time.deltaTime);
        }
    }
}
