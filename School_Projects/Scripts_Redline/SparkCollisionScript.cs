using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkCollisionScript : MonoBehaviour
{
    public ParticleSystem sparkLeft;
    public ParticleSystem sparkRight;
    

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "WallLeft" )
        {
            sparkLeft.Play();
        }

        if (other.gameObject.tag == "WallRight")
        {
            sparkRight.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        sparkLeft.Stop();
        sparkRight.Stop();
    }
}
