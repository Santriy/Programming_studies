using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody e_rigbod;

    public GameObject player;
    public float enemySpeed = 3f;

    public int scoreOnDeath;

    public float health = 100f;
    public float lockPos;
    public float aggroDistance = 25;

    private float originalSpeed;
    private float slowSpeed;

    public float slowAreaCounter = 0;

    public float poisonTimer;
    public int poisonTicks;
    
    //tee prosentuaalinen poison laskuri juttunen


    public bool poisoned = false;
    public bool aggroOn = false;
    public bool slowed = false;
    
    void Start()
    {
        e_rigbod = GetComponent<Rigidbody>();
        e_rigbod.sleepThreshold = 0.0f;
        originalSpeed = enemySpeed;
        slowSpeed = enemySpeed / 2;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {


        if (slowed == true) { enemySpeed = slowSpeed; }
        if (slowed == false) { enemySpeed = originalSpeed; }
        
        if (poisoned == true)
        {
            poisonTimer += Time.deltaTime;

            if (poisonTimer >= 2f)
            {
                poisonTicks++;
                health -= 5f;
                poisonTimer = 0f;
            }

            if (poisonTicks == 4f)
            {
                poisoned = false;
                poisonTicks = 0;
                poisonTimer = 0f;
            }          
        }
        

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if(distanceToPlayer <= aggroDistance)
        {
            aggroOn = true;
        }

        if(aggroOn == true)
        {
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
            transform.LookAt(player.transform.position);
            transform.rotation = Quaternion.Euler(lockPos, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        if(health <= 0f)
        {
            Destroy(gameObject);
            GameManager.scoreAmount += scoreOnDeath;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject, 0.01f);
            health -= 10f;
        }

        if (other.gameObject.tag == "PoisonBullet")
        {
            Destroy(other.gameObject, 0.1f);
            poisoned = true;
        }

        if (other.tag == "SlowArea") 
        { 
            //slowed = true; 
            slowAreaCounter++; 
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "SlowArea") 
        { 
            //slowed = false;
            slowAreaCounter--;
        }
    }


    private void LateUpdate()
    {
        if (slowAreaCounter > 0) { slowed = true; }
        else { slowed = false; }
    }



}