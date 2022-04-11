using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This checks wheter you are behind an object tagged "FrontAsset" and if this is true, fades the object to transparent until you exit the colliderbox in said object.
//This is attached to the player character so that it works on all the different "FrontAsset" objects in the scene.

public class TransparentScript : MonoBehaviour
{
    SpriteRenderer spRend;
   
    private void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FrontAsset"))
        {                 
            spRend = collision.GetComponent<SpriteRenderer>();
            if(spRend != null)
            {
                StartCoroutine(FadeTo(0.5f, 1.0f));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FrontAsset"))
        {           
            if (spRend != null)
            {
                StartCoroutine(FadeTo(1.0f, 1.0f));
            }
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = spRend.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            spRend.color = newColor;
            yield return null;
        }
    }

}
