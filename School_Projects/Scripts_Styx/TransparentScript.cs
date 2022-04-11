using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
