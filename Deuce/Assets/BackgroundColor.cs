using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public bool DarknessBool;

    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(DarknessBool == true)
        {
            Sprite.color = new Color (0.2f,0.2f,0.2f);
        }
        else
        {
            Sprite.color = new Color(1f, 1f, 1f);
        }
    }
}
