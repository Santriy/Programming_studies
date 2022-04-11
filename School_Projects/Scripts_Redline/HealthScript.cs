using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider sliderH;
    public static float healthMax = 40;
    public static float health = 40;

    private void Start()
    {
        health = healthMax;
    }

    public void Update()
    {
        sliderH.value = health;
    }
}
