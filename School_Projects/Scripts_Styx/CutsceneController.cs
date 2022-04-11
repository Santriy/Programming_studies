using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    PlayerMovement playerMovement;

    public GameObject levelBoundary;

    public bool walkRight;
    public bool inCutScene;
    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (inCutScene)
        {
            if (walkRight == true)
            {                
                playerMovement.WalkRight();
                if (playerMovement.collidedWithCutsceneTrigger == true)
                {
                    walkRight = false;
                    return;
                }
                return; 
            }
            else
            {
                playerMovement.Stop();
                inCutScene = false;
            }
        }

        if (!inCutScene)
        {
            levelBoundary.SetActive(true);
        }

    }


}
