using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundTriggerScript : MonoBehaviour
{    
    public AudioSource myAudio;
    public AudioClip pickupSound, coinSound, enemyHit;
    
    private void OnTriggerEnter(Collider other)
    {       
        if(other.gameObject.tag =="Enemy")
        {
            myAudio.PlayOneShot(enemyHit, 0.5f);
        }

        if(other.gameObject.tag == "BoostPickup")
        {
            myAudio.PlayOneShot(pickupSound, 0.3f);
        }

        if (other.gameObject.tag == "HealthPickup")
        {
            if(HealthScript.health != HealthScript.healthMax)
            {
                myAudio.PlayOneShot(pickupSound, 0.3f);
            }

        }

        if (other.gameObject.tag == "ScorePickup")
        {
            myAudio.PlayOneShot(coinSound, 0.3f);
        }
    }
}
