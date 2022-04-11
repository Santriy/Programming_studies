using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : MonoBehaviour
{
    public float timer;
    public float lifeTime = 10;
    public float speed;

    void Update()
    {
        timer += Time.deltaTime;

        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
        if(timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
