using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayerController : MonoBehaviour
{

    //public static float score = 0f;
    public static bool frozen = false;
    public float force = 100f;

    public Animator player_anim;

    public float speed = 0f;
    public float maxSpeed = 200f;
    public float boostSpeed;
    public float acceleration;

    public static float stopTimer;

    public float boostMulti = 1.5f;
    public float boostDecrease = 2;

    public Transform spawnPoint;
    
    
   
    private void Start()
    {
        player_anim = gameObject.GetComponent<Animator>();
        BoostScript.boost = 10f;
        stopTimer = 1f;
        speed = maxSpeed;
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        boostSpeed = maxSpeed * boostMulti;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ScorePickup")
        {
            //score++;
            TimerScript.timeAdd = true;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "HealthPickup")
        {

            if(HealthScript.health != HealthScript.healthMax)
            {
                HealthScript.health += 10;
                Destroy(other.gameObject);
            }

        }

        if (other.gameObject.tag == "BoostPickup")
        {
            Destroy(other.gameObject);
            BoostScript.boost += 5;
        }

        if(other.gameObject.tag == "Enemy")
        {
            player_anim.SetTrigger("PlayerHitEnemy");
            HealthScript.health -= 10;
            speed = 0f;
            stopTimer = 0f;
            frozen = true;
        }

        if(other.gameObject.tag == "Goal")
        {
            transform.position = spawnPoint.position;
        }

    }


    public void Update()
    {
        stopTimer += Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (frozen == false)
        {

            if (Input.GetButtonDown("Jump") && BoostScript.boost >= 0)
            {
                player_anim.SetBool("BoostAnim", true);
            }

            if (Input.GetButtonUp("Jump") || BoostScript.boost <= 0.5f)
            {
                player_anim.SetBool("BoostAnim", false);
            }

            if (Input.GetButton("Jump") && BoostScript.boost >= 0)
            {
                speed = boostSpeed;
                BoostScript.boost -= boostDecrease * Time.deltaTime;
            }

            else
            {
                speed = maxSpeed;
            }
        }

        else if (stopTimer > 0.5f)
        {
            frozen = false;
        }

        if (HealthScript.health == 0)
        {         
            GameManager.deathCon = true;
        }
    }

    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x, 25f, transform.position.z) ;

        if(frozen)
        {
            hor = 0;
        }

        if (Input.GetButton("Horizontal"))
        {            
            transform.Translate(transform.right * force * hor * Time.deltaTime);        
        }       
    }

}
