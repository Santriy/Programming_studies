using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public Transform player;
    public float offsetX, offsetY, offsetZ;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Update()
    {
        transform.parent = player;
        transform.position = new Vector3(player.position.x + offsetX, player.position.y + offsetY, player.position.z + offsetZ);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGERÖITY!");

         if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("TUHOTTU!");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }       
    }
   
}