using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    public ParticleSystem pickupEffect;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(gameObject.tag == "HealthKit")
            {
                if (GameManager.healthKitsAtMax == false)
                {
                    Debug.Log("Health get");
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    Death();
                }
            }

            if (gameObject.tag == "BoostKit")
            {
                if (GameManager.boostKitsAtMax == false)
                {
                    Debug.Log("Boost get");
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    Death();
                }
            }
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }


}
