using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public Text uIElementHealth;
    public Text uIElementBoost;
    public Text uIScoreAmount;
    public float healthPickupCooldown = 30f;
    public float boostPickupCooldown = 30f;
    public float healthPickupTimer = 30;
    public float boostPickupTimer = 30;

    public bool healthPickupUsed = false;
    public bool boostPickupUsed = false;

    private void Start()
    {
        healthPickupTimer = healthPickupCooldown;
        boostPickupTimer = boostPickupCooldown;
    }

    void Update()
    {
        uIElementHealth.text = "Health Kits : " + GameManager.healthKitAmount;
        uIElementBoost.text = "Boost Kits : " + GameManager.boostKitAmount;
        uIScoreAmount.text = "Score : " + GameManager.scoreAmount;


        if (Input.GetKey(KeyCode.E) && healthPickupUsed == false && GameManager.healthKitAmount != 0)
        {
            GameManager.healthKitAmount--;
            healthPickupUsed = true;
        }

        if (healthPickupUsed == true)
        {
            healthPickupTimer -= Time.deltaTime;
            if(healthPickupTimer <= 0f) { healthPickupUsed = false; healthPickupTimer = healthPickupCooldown; }
        }

        if (Input.GetKey(KeyCode.Q) && boostPickupUsed == false && GameManager.boostKitAmount != 0)
        {
            GameManager.boostKitAmount--;
            boostPickupUsed = true;
        }

        if (boostPickupUsed == true)
        {
            boostPickupTimer -= Time.deltaTime;
            if (boostPickupTimer <= 0f) { boostPickupUsed = false; boostPickupTimer = boostPickupCooldown; }
        }

    }
}
