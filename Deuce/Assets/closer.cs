using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closer : MonoBehaviour
{

    public GameObject bbox;

    void Start()
    {
        bbox = gameObject;
        bbox.SetActive(false);
    }
}
