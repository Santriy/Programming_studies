using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject[] carsToSpawn;
    public float spawnTime = 3;
    public float timer;

    public int randomNum;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnTime)
        {
            spawnTime = Random.Range(5,14);

            randomNum = Random.Range(0, 3);
            Instantiate(carsToSpawn[randomNum], transform.position, transform.rotation);
            timer = 0f;
        }


    }
}
