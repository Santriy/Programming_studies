using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : MonoBehaviour
{
    public float effectTime = 4f;
    public float timer;


    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= effectTime) { transform.position = new Vector3(0, -50, 0); Death(); }
        
    }

    void Death()
    {
        Destroy(gameObject,0.1f);
    }
}
