using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashlidmovement : MonoBehaviour
{
    Rigidbody tr_rb;
    public float force = 20;

    private void Start()
    {
        tr_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
            
    }

    private void OnCollisionStay(Collision collision)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            tr_rb.AddForce(transform.up * force * Time.deltaTime);
        }
    }
}
