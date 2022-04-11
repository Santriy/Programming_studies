using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingScript2 : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mousePos.y;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.y = 0f;
        transform.LookAt(mousePos);
    }
}
