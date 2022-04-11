using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is a working, but sub-optimal script for handing dialogues. 
//It informs animations to play when talking to the "Charon" NPC which would be better handled in a separate code.

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public GameObject dialogueBox;

    public bool hideNPCAfterDialogue;

    private GameObject charon;
    private Animator chAnim;
    private GameObject player;
    private Animator plAnim;
    

    private Queue<string> sentences;

    public float delay = 0.1f;
    public string currentText = "";
    private string sentence;

    void Start()
    {
        sentences = new Queue<string>();
        charon = GameObject.FindGameObjectWithTag("Charon");
        chAnim = charon.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        plAnim = player.GetComponent<Animator>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        PlayerMovement.disableControls = true;

        plAnim.SetFloat("X", 0);
        plAnim.SetBool("LookingUp", true);

        chAnim.SetBool("InConversation", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        sentence = sentences.Dequeue();
        StartCoroutine(Typewriter());
    }

    IEnumerator Typewriter()
    {
        for (int i = 0; i < sentence.Length; i++)
        {
            currentText = sentence.Substring(0, i);
            dialogueText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    void EndDialogue()
    {
        DialogueTrigger.inDialogue = (false);
        plAnim.SetBool("LookingUp", false);
        dialogueBox.SetActive(false);
        chAnim.SetBool("InConversation", false);
        PlayerMovement.disableControls = false;
        Debug.Log("End of conversation.");
        if (hideNPCAfterDialogue)
        {
            DialogueTrigger.hideNPC = true;
        }
    }
}
