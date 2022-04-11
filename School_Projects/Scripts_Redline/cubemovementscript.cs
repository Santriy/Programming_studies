using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemovementscript : MonoBehaviour
{
    public float movespeed = 5;

    void Update()
    {
        transform.Translate(Vector3.right * movespeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "WallLeft" || other.gameObject.tag == "WallRight")
        {
            movespeed = -movespeed;
        }
    }

}
