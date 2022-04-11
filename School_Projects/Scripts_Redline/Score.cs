using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float scoreAmount;
    public Text scoreText;

    public void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = GameObject.FindGameObjectsWithTag("ScorePickup").Length;
    }

    public void Update()
    {       
        scoreText.text = "Coins left : " + scoreAmount;
    }

    public void LateUpdate()
    {
        scoreAmount = GameObject.FindGameObjectsWithTag("ScorePickup").Length;
    }

}
    
