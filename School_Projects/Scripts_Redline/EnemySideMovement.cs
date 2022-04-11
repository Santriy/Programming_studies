using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideMovement : MonoBehaviour
{
    public float moveSpeed = 40f;

    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);      
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WallLeft" || other.gameObject.tag == "WallRight")
        {
            moveSpeed = -moveSpeed;
        }
    }
}
