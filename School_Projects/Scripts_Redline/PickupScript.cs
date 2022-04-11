using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    //public Transform shield;
    public ParticleSystem pickupEffect;
    public AudioSource myAudio;
    public AudioClip pickupAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            myAudio.PlayOneShot(pickupAudio, 1f);
            
        }

        
    }        
    
}
