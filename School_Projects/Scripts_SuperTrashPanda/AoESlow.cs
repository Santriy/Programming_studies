using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoESlow : MonoBehaviour
{
    public GameObject AoEEffect;
    public string[] TagList = { "Enemy", "Asset"};


    private void OnTriggerEnter(Collider other)
    {
        foreach (string TagCheck in TagList)
        {
            if(other.tag == TagCheck)
            {
                Vector3 spawnLocation = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);

                Instantiate(AoEEffect, spawnLocation, AoEEffect.transform.rotation);
                Destroy(gameObject);
            }
        }

    }


}
