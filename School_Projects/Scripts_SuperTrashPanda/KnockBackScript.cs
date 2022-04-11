using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackScript : MonoBehaviour
{

    public float knockBackSpeed = 8f;
    public float knockBackDistance = 3f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            transform.position = Vector3.Lerp(transform.position, (Vector3.back * knockBackDistance), knockBackSpeed * Time.deltaTime);
        }
    }

}
