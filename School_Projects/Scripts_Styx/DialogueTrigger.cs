using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script has a distance check that determines if you are close enough to initiate the dialogue.

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;


    public static bool hideNPC;
    public static bool clicked;

    public bool startDialogue;
    public static bool inDialogue;


    public float dialogueTriggerDistance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        if (clicked)
        {
            startDialogue = true;
            clicked = false;
        }
        else
        {
            startDialogue = false;
        }


        float distToPlayer = Vector2.Distance(player.transform.position, transform.position);

        if (dialogueTriggerDistance > distToPlayer && startDialogue && !inDialogue)
        {
            startDialogue = false;
            TriggerDialogue();
            inDialogue = true;
        }

        if (hideNPC)
        {
            //gameObject.SetActive(false);
        }
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
