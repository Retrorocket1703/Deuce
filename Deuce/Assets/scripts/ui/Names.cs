using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Names
{
    [TextArea(1, 3)]
    public string[] name;
    public int CurrentName;


    void Start()
    {
        CurrentName = 0;
    }
}
