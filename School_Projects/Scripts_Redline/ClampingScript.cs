using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampingScript : MonoBehaviour
{

    public float clampMin, clampMax;

    void Update()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, clampMin, clampMax);
        transform.position = clampedPosition;
    }
}
