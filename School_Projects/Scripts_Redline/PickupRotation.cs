using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRotation : MonoBehaviour
{

    public float rotateSpeed;

    void Update()
    {
        transform.Rotate (0, rotateSpeed * Time.deltaTime,0);
    }
}
