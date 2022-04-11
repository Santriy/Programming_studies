using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public float movingSpeed;

    public int random;
    public GameObject[] enemies;
    public float timer;
    public float difficultyTimer;
    public float difficultyUpSeconds = 20;
    public float difficulty = 1;
    private float spawntimeorig;
    public float spawntime;

    private void Start()
    {
        spawntimeorig = spawntime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
        


        timer += Time.deltaTime;

        difficultyTimer += Time.deltaTime;

        spawntime = spawntimeorig / (difficulty / 2);

        if(difficultyTimer >= difficultyUpSeconds)
        {
            difficultyTimer = 0f;
            difficulty++;
        }


        if(timer >= spawntime)
        {
            Randomizer();
            Instantiate(enemies[random], transform.position, transform.rotation);
            timer = 0f;
        }
    }

    void Randomizer()
    {
        random = Random.Range(0,3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            movingSpeed = -movingSpeed;
        }

    }
}
