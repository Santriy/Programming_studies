using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int healthKitAmount = 3;
    public static int maxkits;

    public static int boostKitAmount = 1;
    public static int maxBoostKits;

    public static bool healthKitsAtMax = false;
    public static bool boostKitsAtMax = false;
    
    public int healthKitCap = 5;
    public int boostKitCap = 3;

    public static int scoreAmount = 0;

    private AudioSource audioSource;
    public AudioClip healthSoundEffect;
    public AudioClip boosterSoundEffect;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        maxkits = healthKitCap;
        maxBoostKits = boostKitCap;
    }

    
    void Update()
    {
        PickupManagement();




    }
    void PickupManagement()
    {
        if( healthKitAmount == maxkits ) { healthKitsAtMax = true; }
        else { healthKitsAtMax = false; }

        if (boostKitAmount == maxBoostKits) { boostKitsAtMax = true; }
        else { boostKitsAtMax = false; }
    }

}

