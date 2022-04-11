using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{

    public static bool timeAdd = false;
    public float timeRemaining = 30f;
    public static bool timerIsRunning = true;
    public Text timer;


    void Start()
    {
        timerIsRunning = true;
        timer = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                if(timeAdd == true)
                {
                    timeRemaining += 2.5f;
                    timeAdd = false;
                }

                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                
            }

            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                timeAdd = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("Time left = {0:0}:{1:00}",minutes,seconds);
    }
}
