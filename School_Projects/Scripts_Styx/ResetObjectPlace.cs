using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObjectPlace : MonoBehaviour
{
    private Vector2 startPos;
    public bool resetPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (resetPos)
        {
            ResetPos();            
        }
    }

    public void ResetPos()
    {
        transform.position = startPos;
        resetPos = !resetPos;
    }
}
