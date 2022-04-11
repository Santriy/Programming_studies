using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ClicknDrag clicknDrag;
    [SerializeField]GameObject mainCamera;
    MenuScript menuScript;
    CutsceneController cutsceneController;

    public GameObject InteractionIndicator;

    public Texture2D CustomCursor;
    public Texture2D InteractionCursor;

    public GameObject crossfade;

    private void Awake()
    {
        clicknDrag = mainCamera.GetComponent<ClicknDrag>();
        menuScript = GameObject.Find("Canvas").GetComponent<MenuScript>();
        cutsceneController = FindObjectOfType<CutsceneController>();
        crossfade.SetActive(true);
        //DisableControls();
    }

    private void Start()
    {
        Cursor.visible = true;
        Cursor.SetCursor(CustomCursor, Vector2.zero, CursorMode.ForceSoftware);
    }


    public void Update()
    {
        if (clicknDrag.interactionOn || menuScript.gamePaused)
        {
            Cursor.visible = true;
            Cursor.SetCursor(CustomCursor, Vector2.zero, CursorMode.ForceSoftware);
            if (clicknDrag.interactionOn)
            {
                InteractionIndicator.SetActive(true);               
            } 
        }
        else
        {
            Cursor.SetCursor(CustomCursor, Vector2.zero, CursorMode.ForceSoftware);
            Cursor.visible = true;
            InteractionIndicator.SetActive(false);
        }
        if (clicknDrag.interactable == true || clicknDrag.interactionOn == true)
        {
            Debug.Log("Interactable");
            Cursor.SetCursor(InteractionCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(CustomCursor, Vector2.zero, CursorMode.ForceSoftware);
            return;
        }
    }

    public void DisableControls()
    {
        PlayerMovement.disableControls = true;
        Invoke("EnableControls", 2f);
    }
    public void EnableControls()
    {
        PlayerMovement.disableControls = false;
    }
}
