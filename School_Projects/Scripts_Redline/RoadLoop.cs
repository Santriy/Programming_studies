using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLoop : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public float offset;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed)/10;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
        
    }
}
