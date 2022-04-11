using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A class for dialogue script to use.

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences;
}
