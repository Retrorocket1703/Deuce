using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

    public Text NameText;
    public Dialogue dialogue;
    public GameObject dBox;
    public bool DS;
    public bool HasEntered;
    public bool OnEnter;
    public bool instaD;

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

        if (OnEnter == false)
        {
            if (HasEntered == true)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    if (counter == 0)
                    {
                        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                        counter = +1;
                    }

                    if (counter >= 1)
                    {
                        dialogue.CurrentName += 1;
                        FindObjectOfType<DialogueManager>().DisplayNextSentence();
                    }
                }
            }
        }       
        else
        {
            if (instaD == true)
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
                            instaD = false;
                        }
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            instaD = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HasEntered = false;
            counter = 0;
            dialogue.CurrentName = 0;
            DS = false;
            dman.endDCalled = false;
            instaD = true;
        }
    }
}
