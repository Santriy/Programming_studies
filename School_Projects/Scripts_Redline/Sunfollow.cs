using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunfollow : MonoBehaviour
{
    public Transform target;
    public float offsetX, offsetY, offsetZ;
    
    void Update()
    {
        transform.position = new Vector3(target.position.x + offsetX, target.position.y + offsetY, target.position.z + offsetZ);
    }
}
