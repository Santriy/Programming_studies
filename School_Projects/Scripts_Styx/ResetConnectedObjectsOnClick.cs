using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A simple object reset script I did for a "puzzle" element of the game. Allows you to click on a set object and then resets the objects connected to it in their
//original positions.

//Also controls the animations for this "Pillar" object that works as the reset.

public class ResetConnectedObjectsOnClick : MonoBehaviour
{
    public GameObject[] puzzleObjects;
    private Vector2[] startPos;
    private Quaternion[] startRot;
    private Collider2D targetObj;
    [SerializeField] private int resetTime;
    [SerializeField] private float timer;

    [SerializeField] private Animator pillarGlow;
    [SerializeField] private Animator pillarHat;


    private void Start()
    {
        startPos = new Vector2[puzzleObjects.Length];
        startRot = new Quaternion[puzzleObjects.Length];


        for (int i = 0; i < puzzleObjects.Length; i++)
        {
            startPos[i] = puzzleObjects[i].transform.position;
            startRot[i] = puzzleObjects[i].transform.rotation;
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetObj = Physics2D.OverlapPoint(mouseposition);

        if (resetTime < timer)
        {
            pillarGlow.SetBool("PillarActive", true);
            pillarHat.SetBool("PillarActive", true);
        }

        if (targetObj.tag == "ResetObelisk" && Input.GetMouseButtonDown(0) && resetTime < timer)
        {
            pillarGlow.SetBool("PillarActive", false);
            pillarHat.SetBool("PillarActive", false);

            timer = 0f;

            for (int i = 0; i < puzzleObjects.Length; i++)
            {
                puzzleObjects[i].transform.position = startPos[i];
                puzzleObjects[i].transform.rotation = startRot[i];
            }
        }
    }
}
