using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    [SerializeField] private int minTime;
    [SerializeField] private int maxTime;


    public AudioSource randomsound;

    public AudioClip[] audioSources;
    void Start()
    {
        CallAudio();
    }

    void CallAudio()
    {
        Invoke("RandomSound", Random.Range(minTime, maxTime));
    }

    void RandomSound()
    {
        randomsound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomsound.Play();
        CallAudio();
    }
}
