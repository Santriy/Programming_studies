using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormAIScript : MonoBehaviour
{
    public Animator myAnimator;
    public GameObject player;

    public float attackDistance;


    void Start()
    {
        myAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
       
    }


    void Update()
    {
        

        if (attackDistance >=  Vector2.Distance(transform.position, player.transform.position))
        {
            myAnimator.SetBool("Attack", true);
        }
        else
        {
            myAnimator.SetBool("Attack", false);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            myAnimator.SetBool("BurrowOn", true);
        }
    }

    void BurrowFalse()
    {
        myAnimator.SetBool("BurrowOn", false);
    }

}
