using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnEnterDialogue : MonoBehaviour {

    public Text NameText;
    public Dialogue dialogue;
    public GameObject dBox;
    public bool DS;
    public bool HasEntered;
    

    private DialogueManager dman;
    private int counter;

    private void Start()
    {
        dBox = GameObject.FindGameObjectWithTag("dBox");
        dman = GetComponent<DialogueManager>();
        counter = 0;
    }

    void Update()
    {
        if (dBox.activeInHierarchy == false)
        {
            dialogue.CurrentName = 0;
            DS = false;
            counter = 0;
        }

        if (dBox.activeInHierarchy == true)
        {
            DS = true;
        }

        if (HasEntered == true)
        {
            if (counter == 0)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                counter = +1;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                if (counter >= 1)
                {
                    dialogue.CurrentName += 1;
                    FindObjectOfType<DialogueManager>().DisplayNextSentence();

                    if (dman.endDCalled == true)
                    {
                        
                    }
                }
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HasEntered = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            HasEntered = false;
            counter = 0;
            dialogue.CurrentName = 0;
            DS = false;
        }
        
    }
}
