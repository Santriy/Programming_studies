using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    public int health;
    public int heartAmount = 3;
    public int distance = 60;
    public RawImage[] hearts;
    public Texture fullHeart;
    public Texture emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        health = heartAmount;       
    }

    public void DealDamage()
    {
        health--;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<MenuScript>().gameOver = true;
        }

        if (health > heartAmount)
        {
            health = heartAmount;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].gameObject.SetActive(true);
                
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }



            if (i < heartAmount)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }

}
