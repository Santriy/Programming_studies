using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawnerScript : MonoBehaviour
{
    public GameObject boost;

    private void Start()
    {
        Instantiate(boost, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Invoke("Spawn", 3f);
        }
    }

    void Spawn()
    {
        Instantiate(boost, transform.position, transform.rotation);
    }
}
