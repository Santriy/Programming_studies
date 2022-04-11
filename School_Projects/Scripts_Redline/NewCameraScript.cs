using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraScript : MonoBehaviour
{
    public Transform target;
    
    public float smoothSpeed = 0.5f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 cameraPos = target.position - offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, cameraPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;
    }

}
