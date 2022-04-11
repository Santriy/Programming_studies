using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawnerScript : MonoBehaviour
{
    public GameObject[] bulletPrefab;

    public Text uIAmmoElement;

    
    public float spawnSpeed = 0.3f;
    public float timer;
    public int currentAmmo;
    public int firstAmmoNum, lastAmmoNum;
    public string[] bulletType;



    private void Update()
    {
        uIAmmoElement.text = "Ammo type : " + bulletType[currentAmmo];
        //spawnSpeed = 1 * (currentAmmo * 0.3f) + 0.3f;


        //if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        //{
        //    if (currentAmmo == firstAmmoNum)
        //    {
        //        currentAmmo = lastAmmoNum;
        //    }

        //    else
        //    {
        //        currentAmmo--;
        //    }
        //}

        //if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        //{
        //    if(currentAmmo == lastAmmoNum)
        //    {
        //        currentAmmo = firstAmmoNum;
        //    }

        //    else
        //    {
        //        currentAmmo++;
        //    }
        //}

        if(Input.GetKey(KeyCode.Alpha1))
        {
            currentAmmo = 0;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            currentAmmo = 1;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            currentAmmo = 2;
        }

        if (Input.GetButtonDown("Fire1"))
        {        
            timer += Time.deltaTime;

            if(timer >= spawnSpeed)
            {             
                Bullet();
                timer = 0f;
            }
        }

        else
        {
            timer = 0f;

        }
    }

    void Bullet()
    {
        Instantiate(bulletPrefab[currentAmmo], transform.position, transform.rotation);

    }

}
