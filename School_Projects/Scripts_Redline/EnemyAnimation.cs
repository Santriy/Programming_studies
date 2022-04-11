using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator EnemyAnim;
    [SerializeField] private string enemyFall = "EnemyFall";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            EnemyAnim.Play(enemyFall, 0, 0f);
            Destroy(gameObject, 2f);
        }
    }
}
