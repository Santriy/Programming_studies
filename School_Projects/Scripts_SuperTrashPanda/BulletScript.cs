using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10;
    public float lifeTime = 3;

    void Update()
    {
        transform.Rotate(Vector3.up * 200 * Time.deltaTime);
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Invoke("Death", lifeTime);
    }

 


    void Death()
    {
        Destroy(gameObject);
    }
}
