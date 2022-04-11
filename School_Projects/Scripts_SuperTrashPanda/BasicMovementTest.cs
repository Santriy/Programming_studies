using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementTest : MonoBehaviour
{
    public GameObject inventory;

    public float movementSpeed;
    public bool controlsOn;
    public bool controlBasic;
    public bool controlPhysics;
    public float knockBackSpeed = 8f;
    public float knockBackDistance = 3f;
    private float originalY;
    


    public Transform player;

    private void Start()
    {
        
        originalY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, originalY, transform.position.z);

        player.position = transform.position;
        

        if (controlsOn == true)
        {
            if (controlBasic == true)
            {
                MovementBasic();
            }

            if (controlPhysics == true)
            {
                MovementPhysics();
            }
        }

        

    }

    private void FixedUpdate()
    {
        //Vector3 pos = transform.position;
        //pos.x = Mathf.Clamp(pos.x, -80f, -40f);
        //transform.position = pos;
    }

    void MovementBasic()
    {
        //float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");


        

        //if (input.getbutton("horizontal"))
        //{
        //    transform.translate(vector3.right * hor * movementspeed * time.deltatime);
        //}
        
        if (Input.GetButton("Vertical"))
        {
            transform.Translate(Vector3.forward * ver * movementSpeed * Time.deltaTime);
        }

    }

    void MovementPhysics()
    {
        Rigidbody player_r;

        player_r = GetComponent<Rigidbody>();

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (Input.GetButton("Horizontal"))
        {
            player_r.AddForce(Vector3.right * hor * movementSpeed * 10f * Time.deltaTime);
        }

        if (Input.GetButton("Vertical"))
        {
            player_r.AddForce(Vector3.forward * ver * movementSpeed * 10f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //transform.position = Vector3.Lerp(transform.position, (Vector3.back * knockBackDistance), knockBackSpeed * Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position, (transform.position - other.transform.position) * knockBackDistance, knockBackSpeed * Time.deltaTime);
        }

        if (other.gameObject.tag == "HealthKit" && GameManager.healthKitsAtMax == false)
        {
            GameManager.healthKitAmount++;    
        }

        if (other.gameObject.tag == "BoostKit" && GameManager.boostKitsAtMax == false)
        {
            GameManager.boostKitAmount++;
        }
    }

}



