using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool winCon;
    public static bool deathCon;

    public GameObject gameAudio;

    public GameObject winText;
    public GameObject deathText;

    public void Start()
    {

        GameManager.winCon = false;
        GameManager.deathCon = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("ScorePickup").Length == 0)
        {
            winCon = true;
        }

        if (winCon == true)
        {

            Winner();
        }
        
        if(deathCon == true || TimerScript.timerIsRunning == false)
        { 
                      
            Invoke("Death", 0f);
        }

    }

    public void Death()
    {
        gameAudio.SetActive(false);

        Time.timeScale = 0f;   
        deathText.SetActive(true);
        
        HealthScript.health = HealthScript.healthMax;
        BoostScript.boost = 0f;
    }

    public void Winner()
    {
        gameAudio.SetActive(false);
        Time.timeScale = 0f;
        winText.SetActive(true);
        
    }

}
