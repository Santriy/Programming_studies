using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//With this code, you are able to move objects with the right tag on screen with your mouse.
//It also checks if and object is considered interactable so that other scripts can act based on it.
//It should automatically disable all the collision boxes in your object, and possible child objects and enable them when you let go of the object.


public class ClicknDrag : MonoBehaviour
{
    public bool interactionOn;
    public bool interactable;

    public LayerMask layerMask;

    public bool distanceCheck;

    [SerializeField] private float grabDistance;

    private Collider2D targetObj;

    public GameObject MouseOverObject;
    public GameObject selectedObj;

    Vector3 offset;
    void Update()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetObj = Physics2D.OverlapPoint(mouseposition, layerMask);
        MouseOverObject = targetObj.transform.gameObject;
        GameObject player = GameObject.FindGameObjectWithTag("Player");



        if (MouseOverObject.CompareTag("Pushable") || MouseOverObject.CompareTag("ResetObelisk"))
        {
            interactable = true;
        }
        else
        {
            interactable = false;
        }



        if (Input.GetMouseButtonDown(0))
        {

            string tObjTag = targetObj.tag;
            if (tObjTag == "Pushable")
            {
                if (Input.GetMouseButton(0))
                {
                    interactionOn = true;
                }
                
                if (distanceCheck)
                {
                    float distToPlayer = Vector2.Distance(targetObj.transform.position, player.transform.position);
                    if (distToPlayer <= grabDistance)
                    {
                        PlayerMovement.disableControls = true;
                        selectedObj = targetObj.transform.gameObject;
                        offset = selectedObj.transform.position - mouseposition;
                        selectedObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

                        foreach (Collider2D c in selectedObj.GetComponentsInChildren<Collider2D>())
                        {
                            c.enabled = false;
                        }

                        foreach (Collider2D c in selectedObj.GetComponents<Collider2D>())
                        {
                            c.enabled = false;
                        }
                    }
                }
                else
                {
                    PlayerMovement.disableControls = true;
                    selectedObj = targetObj.transform.gameObject;
                    offset = selectedObj.transform.position - mouseposition;
                    selectedObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

                    foreach (Collider2D c in selectedObj.GetComponentsInChildren<Collider2D>())
                    {
                        c.enabled = false;
                    }

                    foreach (Collider2D c in selectedObj.GetComponents<Collider2D>())
                    {
                        c.enabled = false;
                    }                  
                }
                                  
            }
            else
            {             
                targetObj = null;
            }
        }

        if (selectedObj)
        {
            selectedObj.transform.position = mouseposition + offset;
        }

        if (Input.GetMouseButtonUp(0) && selectedObj)
        {
            PlayerMovement.disableControls = false;
            interactionOn = false;
            selectedObj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Debug.Log("Released left mouse button");

            foreach (Collider2D c in selectedObj.GetComponentsInChildren<Collider2D>())
            {
                c.enabled = true;
            }

            foreach (Collider2D c in selectedObj.GetComponents<Collider2D>())
            {
                 c.enabled = true;
            }
            selectedObj = null;
        }


    }

}
