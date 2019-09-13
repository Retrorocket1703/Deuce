using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dboxCloser : MonoBehaviour
{
    private GameObject dbox;

    void Start()
    {
        dbox = gameObject;
        dbox.SetActive(false);
    }
}
