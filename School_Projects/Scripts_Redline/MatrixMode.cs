using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixMode : MonoBehaviour
{
    public static bool matrixMode = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) 
        { 
            matrixMode = !matrixMode; 
        }

        if (matrixMode == true)
        {
            ShaderEffect_CRT.scanlineWidth = 0;
        }

        if (matrixMode == false)
        {
            ShaderEffect_CRT.scanlineWidth = 1;
        }

    }
}
