using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleOptionSelector : MonoBehaviour
{
    private Animator anim;

    public bool selected;
    public int currentSelection;
    public int selectionNumber;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentSelection = 1;
        anim.SetBool("IsSelected",selected);
    }

    void Update()
    {
        Inputcheck();
        
        if (currentSelection == selectionNumber)
        {
            selected = true;
        }
    }

    void Inputcheck()
    {
        if(Input.GetKeyDown("leftarrow"))
        {
            currentSelection = currentSelection - 1;
        }

        if(Input.GetKeyDown("rightarrow"))
        {
            currentSelection = currentSelection + 1;
        }

        if(currentSelection == 5)
        {
            currentSelection = 4;
        }

        if (currentSelection == 0)
        {
            currentSelection = 1;
        }
    }
}
