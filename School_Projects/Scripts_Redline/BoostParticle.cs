using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostParticle : MonoBehaviour
{
    public ParticleSystem boost;
    public AudioClip boostSound;
    public AudioSource myAudio;

    void Update()
    {
        if(Input.GetButton("Jump") && BoostScript.boost >= 0.5f && NewPlayerController.stopTimer > 0.5f && PauseMenu.GameIsPaused == false)
        {
            boost.Play();

        }

        if (Input.GetButtonDown("Jump") && BoostScript.boost >= 0.5f && NewPlayerController.stopTimer > 0.5f && PauseMenu.GameIsPaused == false)
        {
            myAudio.Play();

        }


        else
        {
            boost.Stop();
        }

    }
}
