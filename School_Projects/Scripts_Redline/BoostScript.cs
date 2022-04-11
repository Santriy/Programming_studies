using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostScript : MonoBehaviour
{
    public Slider slider;
    public static float boost = 10;

    public void Update()
    {
        slider.value = boost;
    }
}
