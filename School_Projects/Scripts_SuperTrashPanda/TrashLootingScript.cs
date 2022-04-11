using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashLootingScript : MonoBehaviour
{
    public bool lootable;
    public bool looted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lootable && Input.GetKeyDown(KeyCode.E) && looted == false)
        {
            int randomCheck = Random.Range(1,3);

            if(1 == randomCheck)
            {
                
            Debug.Log("Löysit roskia");
            }

            else
            {
            Debug.Log("Roskakori oli tyhjä");
            }

            looted = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            lootable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            lootable = false;
        }
    }
}
