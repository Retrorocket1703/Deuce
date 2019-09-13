using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sina : MonoBehaviour
{
    public bool intro;
    public int Sina;
    void Start()
    {
        intro = false;
        Sina = 1;
    }

    void Update()
    {
        if (1 + 1 == 2)
        {
            intro = true;

            if (intro == true)
            {
                Sina = Sina + 5;
            }
        }       
    }
}
